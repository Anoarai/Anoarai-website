using Microsoft.AspNetCore.Mvc;

namespace Website.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        public HomeController()
        {

        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }
    }
}