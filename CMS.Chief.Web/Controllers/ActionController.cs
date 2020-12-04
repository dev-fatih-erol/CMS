using System;
using CMS.Chief.Web.Extensions;
using CMS.Chief.Web.Models;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class ActionController : Controller
    {
        private readonly IHouseService _houseService;

        private readonly IActionService _actionService;

        public ActionController(IHouseService houseService,
            IActionService actionService)
        {
            _houseService = houseService;

            _actionService = actionService;
        }

        [HttpGet]
        [Authorize]
        [Route("House/{houseId:int}/Action/Read")]
        public IActionResult Read(int houseId)
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [Route("House/{houseId:int}/Action/Read")]
        public IActionResult Read(int houseId, ReadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return View();
        }

        [HttpGet]
        [Authorize]
        [Route("House/{houseId:int}/Action/Payment")]
        public IActionResult Payment(int houseId)
        {
            var house = _houseService.GetById(houseId, User.Identity.GetId());

            if (house != null)
            {
                return View();
            }

            return NotFound();
        }

        [HttpPost]
        [Authorize]
        [Route("House/{houseId:int}/Action/Payment")]
        public IActionResult Payment(int houseId, PaymentViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var house = _houseService.GetById(houseId, User.Identity.GetId());

            if (house != null)
            {
                _actionService.Create(new Core.Domain.Action
                {
                    Endeks = 0,
                    Price = model.Price,
                    Description = model.Description,
                    Type = Core.Domain.Type.Payment,
                    CreatedDate = DateTime.Now,
                    HouseId = house.Id
                });

                return View("Success");
            }

            return NotFound();
        }
    }
}