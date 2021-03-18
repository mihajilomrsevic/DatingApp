namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Extensions;
    using API.Helpers;
    using API.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class LikesController : BaseApiController
    {
        /// <summary>The user repository</summary>
        private readonly IUserRepository userRepository;

        /// <summary>The likes repository</summary>
        private readonly ILikesRepository likesRepository;

        /// <summary>Initializes a new instance of the <see cref="LikesController" /> class.</summary>
        /// <param name="userRepository">The user repository.</param>
        /// <param name="likesRepository">The likes repository.</param>
        public LikesController(IUserRepository userRepository, ILikesRepository likesRepository)
        {
            this.userRepository = userRepository;
            this.likesRepository = likesRepository;
        }

        /// <summary>Adds the like.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("{username}")]
        public async Task<ActionResult> AddLike(string username)
        {
            var sourceUserId = User.GetUserId();
            var likedUser = await this.userRepository.GetUserByUsernameAsync(username);
            var sourceUser = await this.likesRepository.GetUserWithLikes(sourceUserId);

            if (likedUser == null)
            {
                return this.NotFound("There is not user by this name");
            }

            if (sourceUser.UserName == username)
            {
                return this.BadRequest("You cannot like yourself");
            }

            var userLike = await this.likesRepository.GetUserLike(sourceUserId, likedUser.Id);

            if (userLike != null)
            {
                return this.BadRequest("You already like this user");
            }

            userLike = new UserLike
            {
                SourceUserId = sourceUserId,
                LikedUserId = likedUser.Id
            };

            sourceUser.LikedUsers.Add(userLike);

            if (await this.userRepository.SaveAllAsync())
            {
                return this.Ok();
            }

            return this.BadRequest("Failed to like user");
        }

        /// <summary>Gets the user likes.</summary>
        /// <param name="likesParams">The likes parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LikeDto>>> GetUserLikes([FromQuery] LikesParams likesParams)
        {
            likesParams.UserId = User.GetUserId();
            var users = await this.likesRepository.GetUserLikes(likesParams);

            Response.AddPaginationHeader(users.CurrentPage, users.PageSize, users.TotalCount, users.TotalPages);
            return this.Ok(users);
        }
    }
}
