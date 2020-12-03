using CMS.Chief.Web.Extensions;
using CMS.Chief.Web.Models;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }

        [HttpGet]
        [Authorize]
        [Route("Setting")]
        public IActionResult Index()
        {
            var setting = _settingService.GetByChiefId(User.Identity.GetId());

            var model = new SettingViewModel
            {
                Price = setting.Price
            };

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("Setting")]
        public IActionResult Index(SettingViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var setting = _settingService.GetByChiefId(User.Identity.GetId());

            if (setting != null)
            {
                setting.Price = model.Price;

                _settingService.SaveChanges();

                return View("Success");
            }

            return NotFound();
        }
    }
}
