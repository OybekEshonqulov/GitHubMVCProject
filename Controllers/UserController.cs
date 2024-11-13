using Microsoft.AspNetCore.Mvc;

namespace newMVC.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
