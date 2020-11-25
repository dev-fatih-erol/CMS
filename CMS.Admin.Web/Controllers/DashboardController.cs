using CMS.Admin.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("Dashboard")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Authorize]
        [Route("Dashboard/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("Dashboard/Create")]
        public IActionResult Create(CreateViewModel model)
        {
            return View();
        }
    }
}