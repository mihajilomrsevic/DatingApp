namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserParams : PaginationParams
    {
        /// <summary>Gets or sets the current username.</summary>
        /// <value>The current username.</value>
        public string CurrentUsername { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>Gets or sets the minimum age.</summary>
        /// <value>The minimum age.</value>
        public int MinAge { get; set; } = 18;

        /// <summary>Gets or sets the maximum age.</summary>
        /// <value>The maximum age.</value>
        public int MaxAge { get; set; } = 150;

        /// <summary>Gets or sets the order by.</summary>
        /// <value>The order by.</value>
        public string OrderBy { get; set; } = "lastActive";
    }
}
