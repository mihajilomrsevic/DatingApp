namespace API.DTOs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CreateMessageDto
    {
        /// <summary>Gets or sets the recipient username.</summary>
        /// <value>The recipient username.</value>
        public string RecipientUsername { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>The content.</value>
        public string Content { get; set; }
    }
}
