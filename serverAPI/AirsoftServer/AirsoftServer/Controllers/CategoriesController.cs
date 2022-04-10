namespace AirsoftServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.CategoryService;

    public class CategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAll()
        {
            var categories = await this.categoryService.GetAllCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet]
        [Route("newest")]
        public async Task<IActionResult> GetNewest()
        {
            var categories = await this.categoryService.GetFourNewestCategoriesAsync();

            return Ok(categories);
        }

        [HttpGet]
        [Route("gunSubcategories")]
        public async Task<IActionResult> GetGunSubCategories()
        {
            var subCategories = await this.categoryService.GetGunSubCategoriesAsync();

            return Ok(subCategories);
        }
    }
}
