using System;
using CMS.Admin.Web.Models;
using CMS.Core.Domain;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IRegionService _regionService;
        private readonly IChiefService _chiefService;

        public DashboardController(
            IRegionService regionService,
            IChiefService chiefService)
        {
            _regionService = regionService;
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

        [HttpGet]
        [Authorize]
        [Route("Dashboard/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Route("Dashboard/Create")]
        public IActionResult Create(CreateViewModel model)
        {
            var region = new Region
            {
                Town = model.Town,
                District = model.District,
                City = model.City,
                CreatedDate = DateTime.Now
            };

            _regionService.Create(region);

            var chief = new Chief
            {
                IdentificationNumber = model.IdentificationNumber,
                Name = model.Name,
                Surname = model.Surname,
                UserName = model.UserName,
                Password = model.Password,
                CreatedDate = DateTime.Now,
                RegionId = region.Id
            };

            _chiefService.Create(chief);

            return View("Success");
        }
    }
}