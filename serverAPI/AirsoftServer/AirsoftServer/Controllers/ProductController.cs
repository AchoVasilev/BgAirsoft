namespace AirsoftServer.Controllers
{
    using CloudinaryDotNet;

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

        [AllowAnonymous]
        [HttpGet]
        [Route("getNewestGuns")]
        public async Task< IActionResult> GetNewestGuns()
        {
            var guns = await this.productService.GetNewestEightGunsAsync();

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getAllGuns")]
        public async Task<IActionResult> GetAllGuns()
        {
            var guns = await this.productService.GetAllGuns();
            var colors = guns.Select(x => x.Color).Distinct().ToList();
            var manufacturers = guns.Select(x => x.Manufacturer).Distinct().ToList();
            var dealers = guns.Select(x => x.DealerName).Distinct().ToList();
            var powers = guns.Select(x => x.Power).Distinct().ToList();

            var allGunsViewModel = new AllGunsViewModel
            {
                AllGuns = guns,
                Colors = colors,
                Manufacturers = manufacturers,
                Dealers = dealers,
                Powers = powers
            };

            return Ok(allGunsViewModel);
        }
    }
}
