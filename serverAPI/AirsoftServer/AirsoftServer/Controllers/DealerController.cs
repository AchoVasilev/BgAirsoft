namespace AirsoftServer.Controllers
{
    using CloudinaryDotNet;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    using Services.DealerService;
    using Services.FileService;

    using ViewModels.Dealer;

    using static GlobalConstants.Constants;

    public class DealerController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDealerService dealerService;
        private readonly IFileService fileService;
        private readonly Cloudinary cloudinary;

        public DealerController(UserManager<ApplicationUser> userManager, IDealerService dealerService, IFileService fileService, Cloudinary cloudinary)
        {
            this.userManager = userManager;
            this.dealerService = dealerService;
            this.fileService = fileService;
            this.cloudinary = cloudinary;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromForm] DealerInputModel model)
        {
            var user = await this.userManager.FindByNameAsync(model.Username);
            if (user != null)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UsernameExistsMsg });
            }

            var imageResult = await this.fileService.UploadImage(cloudinary, model.Image, NameConstants.CloudinaryFolderName);
            string? imageId;
            if (imageResult != null)
            {
                imageId = await this.fileService.AddImageToDatabase(imageResult);
            }
            else
            {
                return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg });
            }

            var result = await this.dealerService.CreateDealerAsync(model, imageId);
            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest(new { ErrorMessage = MessageConstants.UnsuccessfulActionMsg, result.Errors });
        }

        [HttpGet]
        [Authorize]
        [Route("profile")]
        public async Task<IActionResult> Profile()
        {
            var userId = this.User.Claims.First(x => x.Type == "UserId").Value;
            var user = await this.userManager.FindByIdAsync(userId);

            var dealer = await this.dealerService.GetDealerDataAsync(user.Id);

            return Ok(dealer);
        }
    }
}