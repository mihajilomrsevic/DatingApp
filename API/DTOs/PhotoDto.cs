namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PhotoDto
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the URL.</summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is main.</summary>
        /// <value>
        /// <c>true</c> if this instance is main; otherwise, <c>false</c>.</value>
        public bool IsMain { get; set; }
    }
}
