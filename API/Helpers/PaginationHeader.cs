namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PaginationHeader
    {
        /// <summary>Initializes a new instance of the <see cref="PaginationHeader" /> class.</summary>
        /// <param name="currentPage">The current page.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="totalPages">The total pages.</param>
        public PaginationHeader(int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            this.CurrentPage = currentPage;
            this.ItemsPerPage = itemsPerPage;
            this.TotalItems = totalItems;
            this.TotalPages = totalPages;
        }

        /// <summary>Gets or sets the current page.</summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; }

        /// <summary>Gets or sets the items per page.</summary>
        /// <value>The items per page.</value>
        public int ItemsPerPage { get; set; }

        /// <summary>Gets or sets the total items.</summary>
        /// <value>The total items.</value>
        public int TotalItems { get; set; }

        /// <summary>Gets or sets the total pages.</summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; set; }
    }
}
