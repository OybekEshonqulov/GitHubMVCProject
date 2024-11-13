using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using newMVC.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace newMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        public async Task<IActionResult> CheckLogin(string login, string pass)
        {
            if(login=="admin" && pass=="admin")
            {
                var claims = new List<Claim>()
                {
                    new (ClaimTypes.Name,login),
                    new (ClaimTypes.Role,"Admin")
                };
                var claimIdentity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var authProp = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(1)
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claimIdentity),authProp);
                return RedirectToAction("Index", "Admin");

            }
            return RedirectToAction("login", "Home");

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
