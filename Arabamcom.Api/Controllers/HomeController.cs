using Arabamcom.Core.Enums;
using Arabamcom.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Arabamcom.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IAdvertService _service;
        private readonly IAdvertVisitService _visitService;

        public HomeController(IAdvertService service, IAdvertVisitService visitService)
        {
            _service = service;
            _visitService = visitService;
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
        [HttpGet]
        public async Task<IActionResult> Record(int id)
        {
            return Json(await _visitService.Record(id));
        }
    }
}
