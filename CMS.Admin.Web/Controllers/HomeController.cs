using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS.Admin.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace CMS.Admin.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("")]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IndexViewModel model)
        {
            ModelState.AddModelError(string.Empty, "Girdiğin kullanıcı adı veya şifre hiçbir hesapla eşleşmiyor. Hesap bilgilerinizi unuttuysanız lütfen bizimle iletişime geçin.");

            return View(model);
        }
    }
}