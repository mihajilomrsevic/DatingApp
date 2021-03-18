namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class UserDto
    {
        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        public string Username { get; set; }

        /// <summary>Gets or sets the token.</summary>
        /// <value>The token.</value>
        public string Token { get; set; }

        /// <summary>Gets or sets the photo URL.</summary>
        /// <value>The photo URL.</value>
        public string PhotoUrl { get; set; }

        /// <summary>Gets or sets the known as.</summary>
        /// <value>The known as.</value>
        public string KnownAs { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        public string Gender { get; set; }
    }
}
