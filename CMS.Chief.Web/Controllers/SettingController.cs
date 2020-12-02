using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class SettingController : Controller
    {
        [HttpGet]
        [Authorize]
        [Route("Setting")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
