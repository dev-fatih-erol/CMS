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

        private readonly IActionService _actionService;

        public HouseController(IHouseService houseService,
            IActionService actionService)
        {
            _houseService = houseService;

            _actionService = actionService;
        }

        [HttpGet]
        [Authorize]
        [Route("House")]
        public IActionResult Index()
        {
            var houses = _houseService.GetAll(User.Identity.GetId());
            return View(houses);
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
                var newHouse = new House
                {
                    IdentificationNumber = model.IdentificationNumber,
                    Name = model.Name,
                    Surname = model.Surname,
                    Address = model.Address,
                    CounterNumber = model.CounterNumber,
                    ChiefId = User.Identity.GetId(),
                    CreatedDate = DateTime.Now
                };

                _houseService.Create(newHouse);

                _actionService.Create(new Core.Domain.Action
                {
                    Endeks = 0,
                    Price = 0,
                    Description = string.Empty,
                    Type = Core.Domain.Type.Join,
                    CreatedDate = DateTime.Now,
                    ChiefId = 1
                });

                return View("Success");
            }

            ModelState.AddModelError(string.Empty, "Bu sayaç numarasına ait bir hane zaten mevcut");

            return View(model);
        }
    }
}