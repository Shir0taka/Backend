using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApplication12.Models;

namespace WebApplication12.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<Company> companies = new List<Company> { };
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            using (var db = new CompanyContext())
            {
                this.companies = db.Companies.ToList();
            }
            return View(this.companies);
        }
        [HttpPost]
        public IActionResult Index(Company company)
        {
            using (var db = new CompanyContext())
            {
                db.Add(company);
                db.SaveChanges();
                this.companies = db.Companies.ToList();
            }
            return View(this.companies);
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