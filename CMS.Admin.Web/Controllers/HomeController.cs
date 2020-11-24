using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using CMS.Admin.Web.Models;
using CMS.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminService _adminService;

        public HomeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var admin = _adminService.GetByUsernameAndPassword(model.UserName, model.Password);

            if (admin != null)
            {
                var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, admin.Id.ToString())
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
    }
}