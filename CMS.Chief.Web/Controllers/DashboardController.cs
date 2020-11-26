using CMS.Chief.Web.Extensions;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IHouseService _houseService;

        public DashboardController(
            IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        [Authorize]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            var houses = _houseService.GetAll(User.Identity.GetId());
            return View(houses);
        }
    }
}