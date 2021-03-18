namespace API.Services
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using API.Entities;
    using API.Interfaces;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;

    public class TokenService : ITokenService
    {
        /// <summary>The key</summary>
        private readonly SymmetricSecurityKey key;

        /// <summary>The user manager</summary>
        private readonly UserManager<AppUser> userManager;

        /// <summary>Initializes a new instance of the <see cref="TokenService" /> class.</summary>
        /// <param name="config">The configuration.</param>
        /// <param name="userManager">The user manager.</param>
        public TokenService(IConfiguration config, UserManager<AppUser> userManager)
        {
            // od definisanog kljuca iz config fajla pravi simetricni kljuc
            this.key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"]));
            this.userManager = userManager;
        }

        /// <summary>Creates the token.</summary>
        /// <param name="user">The user.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public async Task<string> CreateToken(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var roles = await this.userManager.GetRolesAsync(user);
            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var creds = new SigningCredentials(this.key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}