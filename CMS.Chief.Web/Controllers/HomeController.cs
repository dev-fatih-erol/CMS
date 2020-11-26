using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.Chief.Web.Models;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Chief.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChiefService _chiefService;

        public HomeController(IChiefService chiefService)
        {
            _chiefService = chiefService;
        }

        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var chief = _chiefService.GetByUsernameAndPassword(model.UserName, model.Password);

            if (chief != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, chief.Id.ToString()),
                        new Claim(ClaimTypes.Name, chief.Name +  " " + chief.Surname),
                        new Claim("Region", chief.Town +  ", " + chief.District + ", " + chief.City)
                    };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                          new ClaimsPrincipal(identity),
                          new AuthenticationProperties
                          {
                              ExpiresUtc = DateTime.Now.AddDays(1),
                              IsPersistent = true
                          });

                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError(string.Empty, "Girdiğiniz kullanıcı adı veya şifre hiçbir hesapla eşleşmiyor.");

            return View(model);
        }

        [HttpPost]
        [Authorize]
        [Route("Logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}