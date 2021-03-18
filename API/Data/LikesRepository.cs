namespace API.Data
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
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class LikesRepository : ILikesRepository
    {
        /// <summary>The context</summary>
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="LikesRepository" /> class.</summary>
        /// <param name="context">The context.</param>
        public LikesRepository(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets the user like.</summary>
        /// <param name="sourceUserId">The source user identifier.</param>
        /// <param name="likedUserId">The liked user identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<UserLike> GetUserLike(int sourceUserId, int likedUserId)
        {
            return await this.context.Likes.FindAsync(sourceUserId, likedUserId);
        }

        /// <summary>Gets the user likes.</summary>
        /// <param name="likesParams">The likes parameters.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<PagedList<LikeDto>> GetUserLikes(LikesParams likesParams)
        {
            var users = this.context.Users.OrderBy(u => u.UserName).AsQueryable();
            var likes = this.context.Likes.AsQueryable();

            if (likesParams.Predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == likesParams.UserId);
                users = likes.Select(like => like.LikedUser);
            }

            if (likesParams.Predicate == "likedBy")
            {
                likes = likes.Where(like => like.LikedUserId == likesParams.UserId);
                users = likes.Select(like => like.SourceUser);
            }

            var likedUsers = users.Select(user => new LikeDto
            {
                Username = user.UserName,
                KnownAs = user.KnownAs,
                Age = user.DateOfBirth.CalculateAge(),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain).Url,
                City = user.City,
                Id = user.Id
            });
            return await PagedList<LikeDto>.CreateAsync(likedUsers, likesParams.PageNumber, likesParams.PageSize);
        }

        public async Task<AppUser> GetUserWithLikes(int userId)
        {
            return await this.context.Users
                .Include(x => x.LikedUsers)
                .FirstOrDefaultAsync(x => x.Id == userId);
        }
    }
}
