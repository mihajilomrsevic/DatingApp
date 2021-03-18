namespace API.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using Microsoft.EntityFrameworkCore;

    public class PagedList<T> : List<T>
    {
        /// <summary>Initializes a new instance of the <see cref="PagedList{T}" /> class.</summary>
        /// <param name="items">The items.</param>
        /// <param name="count">The count.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            this.CurrentPage = pageNumber;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.PageSize = pageSize;
            this.TotalCount = count;
            this.AddRange(items);
        }

        /// <summary>Gets or sets the current page.</summary>
        /// <value>The current page.</value>
        public int CurrentPage { get; set; }

        /// <summary>Gets or sets the total pages.</summary>
        /// <value>The total pages.</value>
        public int TotalPages { get; set; }

        /// <summary>Gets or sets the size of the page.</summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        /// <summary>Gets or sets the total count.</summary>
        /// <value>The total count.</value>
        public int TotalCount { get; set; }

        /// <summary>Creates the asynchronous.</summary>
        /// <param name="source">The source.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync(); // vraca broj zapisa
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

        internal static Task<PagedList<MemberDto>> CreateAsync()
        {
            throw new NotImplementedException();
        }
    }
}
