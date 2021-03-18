namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MessageParams : PaginationParams
    {
        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets the container.</summary>
        /// <value>The container.</value>
        public string Container { get; set; } = "Unread";
    }
}
