using Microsoft.AspNetCore.Mvc;
using PortfolioProject2_task2.Models;
using System.Diagnostics;

namespace PortfolioProject2_task2.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.SiteTitle = _configuration["SiteSettings:SiteTitle"];
            ViewBag.EnableGreetingFeature = _configuration.GetValue<bool>("FeatureFlags:EnableGreetingFeature", true);
            return View();
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

        [HttpPost]
        [HttpPost]
        public IActionResult Greet(string name)
        {
            ViewBag.SiteTitle = _configuration["SiteSettings:SiteTitle"];
            ViewBag.EnableGreetingFeature = _configuration.GetValue<bool>("FeatureFlags:EnableGreetingFeature", true);
            ViewBag.Message = string.IsNullOrWhiteSpace(name)
                ? "Hello there!"
                : $"Hello, {name}. Thank-you for joining.";
            return View("Index");
        }
    }
}
