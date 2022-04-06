namespace AirsoftServer.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using Services.CityService;

    public class CityController : BaseController
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        [HttpGet]
        [Route("All")]
        public async Task<IActionResult> GetCities()
        {
            var cities = await this.cityService.GetAllCitiesAsync();

            return Ok(cities);
        }
    }
}
