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
        public async Task<IActionResult> All(int categoryId, decimal price, string gear, string fuel, int page, PriceEnum priceShorting, YearEnum yearShorting, KmEnum kmShorting)
        {
            return Json(await _service.All(categoryId,price,gear,fuel,page,priceShorting,yearShorting,kmShorting));
        }
    }
}
