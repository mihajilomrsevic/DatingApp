namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class CloudinarySettings
    {
        /// <summary>Gets or sets the name of the cloud.</summary>
        /// <value>The name of the cloud.</value>
        public string CloudName { get; set; }

        /// <summary>Gets or sets the API key.</summary>
        /// <value>The API key.</value>
        public string ApiKey { get; set; }

        /// <summary>Gets or sets the API secret.</summary>
        /// <value>The API secret.</value>
        public string ApiSecret { get; set; }
    }
}