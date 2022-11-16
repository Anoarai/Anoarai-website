﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            //portfolioService.CreateNewPortfolioBlockTemplate("Testing Title2", "Icon", "LongDesc", "Adressweb");
            return View("mainpage", portfolioService.GetPortfolio());
        }

        [Route("login")]
        public IActionResult Login()
        {
            return View("login");
        }
    }
}