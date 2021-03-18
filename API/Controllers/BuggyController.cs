namespace API.Controllers
{
    using API.Data;
    using API.Entities;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class BuggyController : BaseApiController
    {
        /// <summary>The context</summary>
        private readonly DataContext context;

        /// <summary>Initializes a new instance of the <see cref="BuggyController" /> class.</summary>
        /// <param name="context">The context.</param>
        public BuggyController(DataContext context)
        {
            this.context = context;
        }

        /// <summary>Gets the secret.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [Authorize]
        [HttpGet("auth")]
        public ActionResult<string> GetSecret()
        {
            return "secret text";
        }

        /// <summary>Gets the not found.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("not-found")]
        public ActionResult<AppUser> GetNotFound()
        {
            var thing = this.context.Users.Find(-1);
            if (thing == null)
            {
                return this.NotFound();
            }

            return this.Ok(thing);
        }

        /// <summary>Gets the server error.</summary>
        /// <returns>
        ///   <br />
        /// </returns>
        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            var thing = this.context.Users.Find(-1);
            var thingToReturn = thing.ToString();

            return thingToReturn;
        }

        [HttpGet("bad-request")]
        public ActionResult<string> GetBadRequest()
        {
            return this.BadRequest();
        }
    }
}
