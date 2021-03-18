namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using API.Data;
    using API.DTOs;
    using API.Entities;
    using API.Extensions;
    using API.Helpers;
    using API.Interfaces;
    using API.Services;
    using AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    [Authorize]
    public class UsersController : BaseApiController
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository userRepository;

        //// private readonly DataContext context;
        /// <summary>The mapper</summary>
        private readonly IMapper mapper;

        /// <summary>The photo service</summary>
        private readonly IPhotoService photoService;

        /// <summary>Initializes a new instance of the <see cref="UsersController" /> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="photoService">The photo service.</param>
        public UsersController(IUserRepository userRepository, IMapper mapper, IPhotoService photoService)
        {
            this.photoService = photoService;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        /// <summary>Gets the users.</summary>
        /// <param name="userParams">The user parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers([FromQuery] UserParams userParams)
        {
            var user = await this.userRepository.GetUserByUsernameAsync(User.GetUsername());
            userParams.CurrentUsername = User.GetUsername();
            if (string.IsNullOrEmpty(userParams.Gender))
            {
                userParams.Gender = user.Gender == "male" ? "female" : "male";
            }

            var users = await this.userRepository.GetMembersAsync(userParams);
            Response.AddPaginationHeader(
                users.CurrentPage,
                users.PageSize,
                users.TotalCount,
                users.TotalPages);

            return this.Ok(users);
        }

        /// <summary>Gets the user.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("{username}", Name = "GetUser")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await this.userRepository.GetMemberAsync(username);
        }

        /// <summary>Updates the user.</summary>
        /// <param name="memberUpdateDto">The member update dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPut]
        public async Task<ActionResult> UpdateUser(MemberUpdateDto memberUpdateDto)
        {
            var user = await this.userRepository.GetUserByUsernameAsync(User.GetUsername());

            this.mapper.Map(memberUpdateDto, user);

            this.userRepository.Update(user);

            if (await this.userRepository.SaveAllAsync())
            {
                return this.NoContent();
            }

            return this.BadRequest("Failed to update user");
        }

        [HttpPost("add-photo")]
        public async Task<IActionResult> AddPhoto(IFormFile file)
        {
            var user = await this.userRepository.GetUserByUsernameAsync(User.GetUsername());

            var result = await this.photoService.AddPhotoAsync(file);

            if (result.Error != null)
            {
                return this.BadRequest(result.Error.Message);
            }

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (user.Photos.Count == 0)
            {
                photo.IsMain = true;
            }

            user.Photos.Add(photo);

            if (await this.userRepository.SaveAllAsync())
            {
                return this.CreatedAtRoute("GetUser", new { username = user.UserName }, this.mapper.Map<PhotoDto>(photo));
            }

            return this.BadRequest("Problem addding photo");
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var user = await this.userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo.IsMain)
            {
                return this.BadRequest("This is already your main photo");
            }

            var currentMain = user.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null)
            {
                currentMain.IsMain = false;
            }

            photo.IsMain = true;

            if (await this.userRepository.SaveAllAsync())
            {
                return this.NoContent();
            }

            return this.BadRequest("Failed to set main photo");
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var user = await this.userRepository.GetUserByUsernameAsync(User.GetUsername());

            var photo = user.Photos.FirstOrDefault(x => x.Id == photoId);

            if (photo == null)
            {
                return this.NotFound();
            }

            if (photo.IsMain)
            {
                return this.BadRequest("You cannot delete your main photo");
            }

            if (photo.PublicId != null)
            {
                var result = await this.photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null)
                {
                    return this.BadRequest(result.Error.Message);
                }
            }

            user.Photos.Remove(photo);

            if (await this.userRepository.SaveAllAsync())
            {
                return this.Ok();
            }

            return this.BadRequest("Failed to delete the photo");
        }
    }
}