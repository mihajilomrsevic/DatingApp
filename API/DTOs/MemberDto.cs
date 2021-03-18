namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Entities;

    public class MemberDto
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets the photo URL.</summary>
        /// <value>The photo URL.</value>
        public string PhotoUrl { get; set; }

        /// <summary>Gets or sets the age.</summary>
        /// <value>The age.</value>
        public int Age { get; set; }

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
        public ICollection<PhotoDto> Photos { get; set; }
    }
}
