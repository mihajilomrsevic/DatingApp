/// <summary>
/// 
/// </summary>
namespace API.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;
    using API.DTOs;
    using API.Entities;
    using API.Interfaces;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class AccountController : BaseApiController
    {
        /// <summary>The token service</summary>
        private readonly ITokenService tokenService;

        /// <summary>The mapper</summary>
        private readonly IMapper mapper;

        /// <summary>The user manager</summary>
        private readonly UserManager<AppUser> userManager;

        /// <summary>The sign in manager</summary>
        private readonly SignInManager<AppUser> signInManager;

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="signInManager">The sign in manager.</param>
        /// <param name="tokenService">The token service.</param>
        /// <param name="mapper">The mapper.</param>
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService, IMapper mapper)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
        }

        /// <summary>Registers the specified register dto.</summary>
        /// <param name="registerDto">The register dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await this.UserExists(registerDto.UserName))
            {
                return this.BadRequest("Username is taken");
            }

            var user = this.mapper.Map<AppUser>(registerDto);

            user.UserName = registerDto.UserName.ToLower();

            //// context.Users.Add(user);
            var result = await this.userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            var roleResult = await this.userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded)
            {
                return this.BadRequest(result.Errors);
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await this.tokenService.CreateToken(user),
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }

        /// <summary>Logins the specified login dto.</summary>
        /// <param name="loginDto">The login dto.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this.userManager.Users
                .Include(p => p.Photos)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Username.ToLower());

            if (user == null)
            {
                return this.Unauthorized("Invalid username");
            }

            var result = await this.signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            if (!result.Succeeded)
            {
                return this.Unauthorized();
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = await this.tokenService.CreateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
                KnownAs = user.KnownAs,
                Gender = user.Gender
            };
        }

        private async Task<bool> UserExists(string username)
        {
            return await this.userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}
