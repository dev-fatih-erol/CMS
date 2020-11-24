using CMS.Admin.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class RegionController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("Region/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("Region/Create")]
        public IActionResult Create(CreateRegionViewModel model)
        {
            return View();
        }
    }
}