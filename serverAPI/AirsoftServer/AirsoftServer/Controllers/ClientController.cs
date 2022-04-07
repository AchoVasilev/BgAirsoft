namespace AirsoftServer.Controllers
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    using Services.ClientService;

    using ViewModels.Client;

    using static GlobalConstants.Constants;

    public class ClientController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IClientService clientService;

        public ClientController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IClientService clientService)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.clientService = clientService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ClientInputModel model)
        {
            var clientId = await this.clientService.CreateClientAsync(model);
            if (clientId == "0")
            {
                return BadRequest(new { ErrorMessage = MessageConstants.InvalidCityMsg });
            }

            var applicationUser = new ApplicationUser
            {
                ClientId = clientId,
                Email = model.Email,
                UserName = model.Username,
                Image = new Image
                {
                    Url = "https://res.cloudinary.com/dpo3vbxnl/image/upload/v1649172192/BgAirsoft/NoAvatarProfileImage_uj0zyg.png",
                    Extension = "png",
                    Name = "NoAvatarProfileImage"
                }
            };

            var result = await this.userManager.CreateAsync(applicationUser, model.Password);
     
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg, result.Errors });
        }
    }
}
