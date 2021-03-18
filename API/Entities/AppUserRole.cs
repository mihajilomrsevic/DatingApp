﻿namespace API.Entities
{
    using Microsoft.AspNetCore.Identity;

    public class AppUserRole : IdentityUserRole<int>
    {
        /// <summary>Gets or sets the user.</summary>
        /// <value>The user.</value>
        public AppUser User { get; set; }

        /// <summary>Gets or sets the role.</summary>
        /// <value>The role.</value>
        public AppRole Role { get; set; }
    }
}
