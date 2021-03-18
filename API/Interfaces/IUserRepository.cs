namespace API.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Helpers;

    public interface IUserRepository
    {
        /// <summary>Updates the specified user.</summary>
        /// <param name="user">The user.</param>
        void Update(AppUser user);

        /// <summary>Saves all asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<bool> SaveAllAsync();

        /// <summary>Gets the users asynchronous.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<IEnumerable<AppUser>> GetUsersAsync();

        /// <summary>Gets the user by identifier asynchronous.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<AppUser> GetUserByIdAsync(int id);

        /// <summary>Gets the user by username asynchronous.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<AppUser> GetUserByUsernameAsync(string username);

        /// <summary>Gets the members asynchronous.</summary>
        /// <param name="userParams">The user parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);

        /// <summary>Gets the member asynchronous.</summary>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<MemberDto> GetMemberAsync(string username);
    }
}
