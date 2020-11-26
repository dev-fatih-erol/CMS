using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IChiefService _chiefService;

        public DashboardController(
            IChiefService chiefService)
        {
            _chiefService = chiefService;
        }

        [HttpGet]
        [Authorize]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            var chiefs = _chiefService.GetAll();
            return View(chiefs);
        }
    }
}