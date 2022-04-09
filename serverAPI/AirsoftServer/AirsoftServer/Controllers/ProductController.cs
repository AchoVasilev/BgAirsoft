namespace AirsoftServer.Controllers
{
    using CloudinaryDotNet;

    using Infrastructure;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    using Models;

    using Services.FileService;
    using Services.ProductService;

    using ViewModels.Item.Guns;
    using static GlobalConstants.Constants;

    [Authorize]
    public class ProductController : BaseController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IProductService productService;
        private readonly IFileService fileService;
        private readonly Cloudinary cloudinary;

        public ProductController(
            UserManager<ApplicationUser> userManager, 
            IProductService productService, 
            IFileService fileService, 
            Cloudinary cloudinary)
        {
            this.userManager = userManager;
            this.productService = productService;
            this.fileService = fileService;
            this.cloudinary = cloudinary;
        }

        [Route("createGun")]
        [HttpPost]
        public async Task<IActionResult> CreateGun([FromForm]GunInputModel model)
        {
            var userId = this.User.Claims.First(x => x.Type == "UserId").Value;
            var user = await this.userManager.FindByIdAsync(userId);
            if (user.DealerId == null)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.InvalidUser });
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

            var gunId = await this.productService.CreateGunAsync(model, user.DealerId, imageId);

            return Ok(new {gunId, model.Name});
        }
    }
}
