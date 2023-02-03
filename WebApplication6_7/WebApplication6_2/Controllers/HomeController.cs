using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq ;
using WebApplication6_2.Models;

namespace WebApplication6_2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Product sobaProduct = new Product("Soba", 5, 6);
        private Product takoyakiProduct = new Product("Takoyaki", 15, 15);
        private Product tonkotsuProduct = new Product("Tonkotsu", 36, 16);
        private Product nabeProduct = new Product("Nabe", 56, 14);

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Message = "";
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserModel user)
        {
            ViewBag.Message = "";
            if (user.Age < 16) {
                ViewBag.Message = "Should be less than 16";
                return View();
            }
            return Redirect("/Home/Order");
        }
        [HttpGet]
        public IActionResult Order() {
            return View();
        }

        [HttpGet]
        public IActionResult Submit()
        {
            return Redirect("/Home/Order");
        }

        [HttpPost]
        public IActionResult Submit(int soba, int takoyaki, int tonkotsu, int nabe)
        {
            List<Product> products = new List<Product> {};

            if (soba != 0) {
                for (int i = 0; i < soba; i++) {
                    products.Add(sobaProduct);
                }
            }
            if (takoyaki != 0)
            {
                for (int i = 0; i < takoyaki; i++)
                {
                    products.Add(takoyakiProduct);
                }
            }
            if (tonkotsu != 0)
            {
                for (int i = 0; i < tonkotsu; i++)
                {
                    products.Add(tonkotsuProduct);
                }
            }
            if (nabe != 0)
            {
                for (int i = 0; i < nabe; i++)
                {
                    products.Add(nabeProduct);
                }
            }

            return View(products);
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