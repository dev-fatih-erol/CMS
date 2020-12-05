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

        private readonly ISettingService _settingService;

        public ActionController(IHouseService houseService,
            IActionService actionService,
            ISettingService settingService)
        {
            _houseService = houseService;

            _actionService = actionService;

            _settingService = settingService;
        }

        [HttpGet]
        [Authorize]
        [Route("House/{houseId:int}/Action/Read")]
        public IActionResult Read(int houseId)
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
        [Route("House/{houseId:int}/Action/Read")]
        public IActionResult Read(int houseId, ReadViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var house = _houseService.GetById(houseId, User.Identity.GetId());

            if (house != null)
            {
                var action = _actionService.GetLastByHouseId(house.Id, Core.Domain.Type.Read);

                if (model.Endeks <= action.Endeks)
                {
                    ModelState.AddModelError(string.Empty, "Girdiğiniz endeks, son endeksden büyük olmalıdır.");

                    return View(model);
                }

                var price = _settingService.GetByChiefId(User.Identity.GetId()).Price;

                var resultPrice = (model.Endeks - action.Endeks) * price;

                _actionService.Create(new Core.Domain.Action
                {
                    Endeks = model.Endeks,
                    Price = resultPrice,
                    Description = model.Description,
                    Type = Core.Domain.Type.Read,
                    CreatedDate = DateTime.Now,
                    HouseId = house.Id
                });

                return View("Success");
            }

            return NotFound();
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