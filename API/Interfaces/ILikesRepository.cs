namespace API.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Helpers;

    public interface ILikesRepository
    {
        /// <summary>Gets the user like.</summary>
        /// <param name="sourceUserId">The source user identifier.</param>
        /// <param name="likedUserId">The liked user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<UserLike> GetUserLike(int sourceUserId, int likedUserId);

        /// <summary>Gets the user with likes.</summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<AppUser> GetUserWithLikes(int userId);

        /// <summary>Gets the user likes.</summary>
        /// <param name="likesParams">The likes parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams);
    }
}
