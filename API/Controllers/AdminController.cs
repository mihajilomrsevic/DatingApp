namespace API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class AdminController : BaseApiController
    {
        /// <summary>The user manager</summary>
        private readonly UserManager<AppUser> userManager;

        /// <summary>Initializes a new instance of the <see cref="AdminController" /> class.</summary>
        /// <param name="userManager">The user manager.</param>
        public AdminController(UserManager<AppUser> userManager)
        {
            this.userManager = userManager;
        }

        /// <summary>Gets the users with roles.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [Authorize(Policy = "RequireAdminRole")]
        [HttpGet("users-with-roles")]
        public async Task<ActionResult> GetUsersWithRoles()
        {
            var users = await this.userManager.Users
                .Include(r => r.UserRoles)
                .ThenInclude(r => r.Role)
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                })
                .ToListAsync();

            return this.Ok(users);
        }

        [HttpPost("edit-roles/{username}")]
        public async Task<ActionResult> EditRoles(string username, [FromQuery] string roles)
        {
            var selectedRoles = roles.Split(",").ToArray();

            var user = await this.userManager.FindByNameAsync(username);

            if (user == null)
            {
                return this.NotFound("Could not find user");
            }

            var userRoles = await this.userManager.GetRolesAsync(user);

            var result = await this.userManager.AddToRolesAsync(user, selectedRoles.Except(userRoles));

            if (!result.Succeeded)
            {
                return this.BadRequest("Failed to add to roles");
            }

            result = await this.userManager.RemoveFromRolesAsync(user, userRoles.Except(selectedRoles));

            if (!result.Succeeded)
            {
                return this.BadRequest("Failed to remove from roles");
            }

            return this.Ok(await this.userManager.GetRolesAsync(user));
        }

        /// <summary>Gets the photos for moderation.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [Authorize(Policy = "ModeratePhotoRole")]
        [HttpGet("photos-to-moderate")]
        public ActionResult GetPhotosForModeration()
        {
            return this.Ok("Admins or moderators can see this");
        }
    }
}
