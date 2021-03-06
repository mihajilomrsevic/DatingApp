﻿namespace API.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class Message
    {
        /// <summary>Gets or sets the identifier.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the sender identifier.</summary>
        /// <value>The sender identifier.</value>
        public int SenderId { get; set; }

        /// <summary>Gets or sets the sender username.</summary>
        /// <value>The sender username.</value>
        public string SenderUsername { get; set; }

        /// <summary>Gets or sets the sender.</summary>
        /// <value>The sender.</value>
        public AppUser Sender { get; set; }

        /// <summary>Gets or sets the recipient identifier.</summary>
        /// <value>The recipient identifier.</value>
        public int RecipientId { get; set; }

        /// <summary>Gets or sets the recipient username.</summary>
        /// <value>The recipient username.</value>
        public string RecipientUsername { get; set; }

        /// <summary>Gets or sets the recipient.</summary>
        /// <value>The recipient.</value>
        public AppUser Recipient { get; set; }

        /// <summary>Gets or sets the content.</summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>Gets or sets the date read.</summary>
        /// <value>The date read.</value>
        public DateTime? DateRead { get; set; }

        /// <summary>Gets or sets the message sent.</summary>
        /// <value>The message sent.</value>
        public DateTime MessageSent { get; set; } = DateTime.Now;

        /// <summary>Gets or sets a value indicating whether [sender deleted].</summary>
        /// <value>
        /// <c>true</c> if [sender deleted]; otherwise, <c>false</c>.</value>
        public bool SenderDeleted { get; set; }

        /// <summary>Gets or sets a value indicating whether [recipient deleted].</summary>
        /// <value>
        /// <c>true</c> if [recipient deleted]; otherwise, <c>false</c>.</value>
        public bool RecipientDeleted { get; set; }
    }
}
