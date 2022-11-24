using Microsoft.AspNetCore.Mvc;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
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

        [HttpGet]
        [Route("")]
        public IActionResult MainPage()
        {
            return View("mainpage");
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }

        //[HttpPost]
        //[Route("upload-image")]
        //public IActionResult Upload(IFormFile file)
        //{
        //    var name = file.FileName;
        //    using var image = SixLabors.ImageSharp.Image.Load(file.OpenReadStream());
        //    image.Mutate(x => x.Resize(256, 256));
        //    image.Save("wwwroot/Icons/Songs/"+ name + ".png");
        //    return Redirect("/");
        //}
    }
}