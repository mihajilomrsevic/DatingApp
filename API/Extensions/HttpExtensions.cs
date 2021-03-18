namespace API.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    using API.Helpers;
    using Microsoft.AspNetCore.Http;

    public static class HttpExtensions
    {
        /// <summary>Adds the pagination header.</summary>
        /// <param name="response">The response.</param>
        /// <param name="currentPage">The current page.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <param name="totalItems">The total items.</param>
        /// <param name="totalPages">The total pages.</param>
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPages);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
