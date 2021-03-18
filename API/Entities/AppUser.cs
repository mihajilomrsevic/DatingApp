namespace API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Extensions;
    using Microsoft.AspNetCore.Identity;

    /// <summary>
    ///   <br />
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        /// <summary>Gets or sets the date of birth.</summary>
        /// <value>The date of birth.</value>
        public DateTime DateOfBirth { get; set; }

        /// <summary>Gets or sets the known as.</summary>
        /// <value>The known as.</value>
        public string KnownAs { get; set; }

        /// <summary>Gets or sets the created.</summary>
        /// <value>The created.</value>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>Gets or sets the last active.</summary>
        /// <value>The last active.</value>
        public DateTime LastActive { get; set; } = DateTime.Now;

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }

        /// <summary>Gets or sets the introduction.</summary>
        /// <value>The introduction.</value>
        public string Introduction { get; set; }

        /// <summary>Gets or sets the looking for.</summary>
        /// <value>The looking for.</value>
        public string LookingFor { get; set; }

        /// <summary>Gets or sets the interests.</summary>
        /// <value>The interests.</value>
        public string Interests { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        public string City { get; set; }

        /// <summary>Gets or sets the country.</summary>
        /// <value>The country.</value>
        public string Country { get; set; }

        /// <summary>Gets or sets the photos.</summary>
        /// <value>The photos.</value>
        public ICollection<Photo> Photos { get; set; }

        /// <summary>Gets or sets the liked by users.</summary>
        /// <value>The liked by users.</value>
        public ICollection<UserLike> LikedByUsers { get; set; }

        /// <summary>Gets or sets the liked users.</summary>
        /// <value>The liked users.</value>
        public ICollection<UserLike> LikedUsers { get; set; }

        /// <summary>Gets or sets the messages sent.</summary>
        /// <value>The messages sent.</value>
        public ICollection<Message> MessagesSent { get; set; }

        /// <summary>Gets or sets the messages received.</summary>
        /// <value>The messages received.</value>
        public ICollection<Message> MessagesReceived { get; set; }

        /// <summary>Gets or sets the user roles.</summary>
        /// <value>The user roles.</value>
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
