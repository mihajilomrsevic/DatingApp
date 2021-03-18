namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LikesParams : PaginationParams
    {
        /// <summary>Gets or sets the user identifier.</summary>
        /// <value>The user identifier.</value>
        public int UserId { get; set; }

        /// <summary>Gets or sets the predicate.</summary>
        /// <value>The predicate.</value>
        public string Predicate { get; set; }
    }
}
