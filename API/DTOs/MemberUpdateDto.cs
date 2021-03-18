namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class MemberUpdateDto
    {
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
    }
}
