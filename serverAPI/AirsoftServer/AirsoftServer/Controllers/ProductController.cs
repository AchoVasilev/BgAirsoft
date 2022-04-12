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
        public async Task<IActionResult> CreateGun([FromForm] GunInputModel model)
        {
            var userId = this.User.Claims.First(x => x.Type == "UserId").Value;
            var user = await this.userManager.FindByIdAsync(userId);
            if (user.DealerId == null)
            {
                return BadRequest(new { ErrorMessage = MessageConstants.InvalidUserMsg });
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

            return Ok(new { gunId, model.Name });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getNewestGuns")]
        public async Task<IActionResult> GetNewestGuns()
        {
            var guns = await this.productService.GetNewestEightGunsAsync();

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("getAllGuns")]
        public async Task<IActionResult> GetAllGuns()
        {
            var guns = await this.productService.GetAllGunsAsync();
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

        [AllowAnonymous]
        [HttpGet]
        [Route("gunsByManufacturer")]
        public async Task<IActionResult> GetGunsByManufacturer([FromQuery] List<string> manufacturers)
        {
            var guns = await this.productService.FilterGunsByManufacturerAsync(manufacturers);

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gunsByDealer")]
        public async Task<IActionResult> GetGunsByDealers([FromQuery] List<string> dealers)
        {
            var guns = await this.productService.FilterGunsByDealerAsync(dealers);

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gunsByColor")]
        public async Task<IActionResult> GetGunsByColors([FromQuery] List<string> colors)
        {
            var guns = await this.productService.FilterGunsByColorAsync(colors);

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gunsByPower")]
        public async Task<IActionResult> GetGunsByPowers([FromQuery] GunQueryModel query)
        {
            var guns = await this.productService.FilterGunsByPowerAsync(query);

            return Ok(guns);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("gunsByCategory")]
        public async Task<IActionResult> GetGunsByCategory([FromQuery] GunQueryModel query)
        {
            var guns = await this.productService.FilterGunsByCategoryAsync(query);
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

        [AllowAnonymous]
        [HttpGet]
        [Route("sortGuns")]
        public async Task<IActionResult> GetOrderedGuns([FromQuery] GunSortModel query)
        {
            var guns = await this.productService.OrderGuns(query);

            return Ok(guns);
        }
    }
}
