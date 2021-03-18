namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaginationParams
    {
        /// <summary>The maximum page size</summary>
        private const int MaxPageSize = 50;

        /// <summary>The page size</summary>
        private int pageSize = 10;

        /// <summary>Gets or sets the size of the page.</summary>
        /// <value>The size of the page.</value>
        public int PageSize
        {
            get => this.pageSize;
            set => this.pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        /// <summary>Gets or sets the page number.</summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; } = 1;
    }
}
