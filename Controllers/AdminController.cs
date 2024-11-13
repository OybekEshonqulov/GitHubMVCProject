using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace newMVC.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
