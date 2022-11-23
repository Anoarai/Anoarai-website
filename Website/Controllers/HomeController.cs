using Microsoft.AspNetCore.Mvc;
using Website.Models;
using Website.Services;

namespace Website.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        private IPortfolioBlockService portfolioService;

        public HomeController(IPortfolioBlockService portfolioServiceInput)
        {
            portfolioService = portfolioServiceInput;
        }

        [Route("")]
        public IActionResult MainPage()
        {
            return View("mainpage");
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }
    }
}