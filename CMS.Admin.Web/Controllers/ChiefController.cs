﻿using System;
using CMS.Admin.Web.Models;
using CMS.Core.Domain;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class ChiefController : Controller
    {
        private readonly IChiefService _chiefService;

        private readonly ISettingService _settingService;

        public ChiefController(
            IChiefService chiefService,
            ISettingService settingService)
        {
            _chiefService = chiefService;

            _settingService = settingService;
        }

        [HttpGet]
        [Authorize]
        [Route("Chief")]
        public IActionResult Index()
        {
            var chiefs = _chiefService.GetAll();
            return View(chiefs);
        }

        [HttpGet]
        [Authorize]
        [Route("Chief/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        [Route("Chief/Create")]
        public IActionResult Create(CreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var chief = _chiefService.GetByUsername(model.UserName);

            if (chief == null)
            {
                var newChief = new Chief
                {
                    IdentificationNumber = model.IdentificationNumber,
                    Name = model.Name,
                    Surname = model.Surname,
                    UserName = model.UserName,
                    Password = model.Password,
                    Town = model.Town,
                    District = model.District,
                    City = model.City,
                    CreatedDate = DateTime.Now
                };

                _chiefService.Create(newChief);

                _settingService.Create(new Setting
                {
                    Price = model.Price,
                    ChiefId = newChief.Id
                });

                return View("Success");
            }

            ModelState.AddModelError(string.Empty, "Bu kullanıcı adı başka bir hesap tarafından zaten kullanılıyor.");

            return View(model);
        }
    }
}