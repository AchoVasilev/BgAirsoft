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

            return new JsonResult(categories);
        }
    }
}
