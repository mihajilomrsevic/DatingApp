namespace API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserLike
    {
        /// <summary>Gets or sets the source user.</summary>
        /// <value>The source user.</value>
        public AppUser SourceUser { get; set; }

        /// <summary>Gets or sets the source user identifier.</summary>
        /// <value>The source user identifier.</value>
        public int SourceUserId { get; set; }

        /// <summary>Gets or sets the liked user.</summary>
        /// <value>The liked user.</value>
        public AppUser LikedUser { get; set; }

        /// <summary>Gets or sets the liked user identifier.</summary>
        /// <value>The liked user identifier.</value>
        public int LikedUserId { get; set; }
    }
}
