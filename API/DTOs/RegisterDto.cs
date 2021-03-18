namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;

    public class RegisterDto
    {
        /// <summary>Gets or sets the name of the user.</summary>
        /// <value>The name of the user.</value>
        [Required] 
        public string UserName { get; set; }

        /// <summary>Gets or sets the known as.</summary>
        /// <value>The known as.</value>
        [Required] 
        public string KnownAs { get; set; }

        /// <summary>Gets or sets the gender.</summary>
        /// <value>The gender.</value>
        [Required] 
        public string Gender { get; set; }

        /// <summary>Gets or sets the date of birth.</summary>
        /// <value>The date of birth.</value>
        [Required] 
        public DateTime DateOfBirth { get; set; }

        /// <summary>Gets or sets the city.</summary>
        /// <value>The city.</value>
        [Required] 
        public string City { get; set; }

        /// <summary>Gets or sets the country.</summary>
        /// <value>The country.</value>
        [Required] 
        public string Country { get; set; }

        /// <summary>Gets or sets the password.</summary>
        /// <value>The password.</value>
        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
