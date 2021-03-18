namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class LikeDto
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets the age.</summary>
        /// <value>The age.</value>
        public int Age { get; set; }

        /// <summary>Gets or sets the known as.</summary>
        /// <value>The known as.</value>
        public string KnownAs { get; set; }

        /// <summary>Gets or sets the photo URL.</summary>
        /// <value>The photo URL.</value>
        public string PhotoUrl { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        public string City { get; set; }
    }
}
