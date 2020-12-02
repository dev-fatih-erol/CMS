using System;
using System.Linq;
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
        [Route("House/Detail/{id:int}")]
        public IActionResult Detail(int id)
        {
            var house = _houseService.GetById(id, User.Identity.GetId());

            if (house != null)
            {
                var actions = _actionService.GetByHouseId(house.Id);

                var model = new DetailViewModel
                {
                    Id = house.Id,
                    IdentificationNumber = house.IdentificationNumber,
                    Name = house.Name,
                    Surname = house.Surname,
                    Address = house.Address,
                    CounterNumber = house.CounterNumber,
                    Actions = actions.Select(a => new ActionViewModel
                    {
                        Id = a.Id,
                        Endeks = a.Endeks,
                        Price = a.Price,
                        Description = a.Description,
                        Type = a.Type.ToType(),
                        CreatedDate = a.CreatedDate
                    }).ToList()
                };

                return View(model);
            }

            return NotFound();
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
                    Type = Core.Domain.Type.Read,
                    CreatedDate = DateTime.Now,
                    HouseId = newHouse.Id
                });

                return View("Success");
            }

            ModelState.AddModelError(string.Empty, "Bu sayaç numarasına ait bir hane zaten mevcut");

            return View(model);
        }
    }
}