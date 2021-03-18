namespace API.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using API.Entities;

    public interface ITokenService
    {
        /// <summary>Creates the token.</summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        Task<string> CreateToken(AppUser user);
    }
}
