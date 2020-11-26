using System;
using CMS.Chief.Web.Extensions;
using CMS.Chief.Web.Models;
using CMS.Core.Domain;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class HouseController : Controller
    {
        private readonly IHouseService _houseService;

        public HouseController(IHouseService houseService)
        {
            _houseService = houseService;
        }

        [HttpGet]
        [Authorize]
        [Route("House/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Route("House/Create")]
        public IActionResult Create(CreateHouseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var house = _houseService.GetByCounterNumber(model.CounterNumber);

            if (house == null)
            {
                _houseService.Create(new House
                {
                     IdentificationNumber = model.IdentificationNumber,
                     Name = model.Name,
                     Surname = model.Surname,
                     Address = model.Address,
                     CounterNumber = model.CounterNumber,
                     ChiefId = User.Identity.GetId(),
                     CreatedDate = DateTime.Now
                });

                return View("Success");
            }

            ModelState.AddModelError(string.Empty, "Bu sayaç numarasına ait bir hane zaten mevcut");

            return View(model);
        }
    }
}