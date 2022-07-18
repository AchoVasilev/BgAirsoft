namespace AirsoftServer.Controllers
{
    using Infrastructure;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    using Services.ClientService;

    using ViewModels.Client;

    using static GlobalConstants.Constants;

    public class ClientController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IClientService clientService;

        public ClientController(UserManager<ApplicationUser> userManager, IClientService clientService)
        {
            this.userManager = userManager;
            this.clientService = clientService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register(ClientInputModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UsernameExistsMsg });
            }

            var result = await this.clientService.CreateClientAsync(model);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg, result.Errors });
        }

        [HttpPut]
        [Authorize]
        [Route("edit")]
        public async Task<IActionResult> Edit(EditClientModel model)
        {
            var result = await this.clientService.EditClient(this.User.GetId(), model);
            if (result)
            {
                return Ok(new { Message = MessageConstants.SuccessfulEditMsg });
            }

            return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
        }

        [HttpGet]
        [Authorize]
        [Route("profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = this.User.Claims.First(x => x.Type == "UserId").Value;
            var user = await this.userManager.FindByIdAsync(userId);

            var client = await this.clientService.GetClientDataAsync(user.Id);

            return Ok(client);
        }
    }
}
