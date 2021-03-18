namespace API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Identity;

    public class AppRole : IdentityRole<int>
    {
        /// <summary>Gets or sets the user roles.</summary>
        /// <value>The user roles.</value>
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
