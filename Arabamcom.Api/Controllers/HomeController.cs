using Arabamcom.Core.Enums;
using Arabamcom.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arabamcom.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IService _service;

        public HomeController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> All(int categoryId, decimal priceMin, decimal priceMax, GearEnum gearFiltering, FuelEnum fuelFiltering, AllSorting allSorting)
        {
            return Json(await _service.All(categoryId, priceMin, priceMax, gearFiltering, fuelFiltering, allSorting));
        }
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            return Json(await _service.Get(id));
        }
    }
}
