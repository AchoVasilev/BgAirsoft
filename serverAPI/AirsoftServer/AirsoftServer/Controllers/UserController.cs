namespace AirsoftServer.Controllers
{
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;

    using Infrastructure;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using Models;

    using ViewModels.Jwt;
    using ViewModels.User;

    using static GlobalConstants.Constants;

    public class UserController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly JwtModel jwtOptions;

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtModel> jwtOptions)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.jwtOptions = jwtOptions.Value;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInputModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user != null && await this.userManager.CheckPasswordAsync(user, model.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.jwtOptions.Key));
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserId", user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                var isClient = user.ClientId != null;

                return Ok(new { token, isClient });
            }

            return BadRequest(new { ErrorMessage = MessageConstants.FailedUserLoginMsg });
        }

        [HttpGet]
        [Route("getDealerId")]
        public async Task<IActionResult> GetDealerId()
        {
            ApplicationUser user;

            try
            {
                user = await this.userManager.FindByIdAsync(this.User.GetId());
            }
            catch (Exception)
            {
                return Ok(null);
            }

            return Ok(new {user.DealerId});
        }
    }
}
