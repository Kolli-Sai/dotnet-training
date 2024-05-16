using Microsoft.AspNetCore.Mvc;
using MVCDemo1.Models;
using System.Diagnostics;

namespace MVCDemo1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;


        public string ShowMessage()
        {
            return " Hello world";
        }

        public ContentResult ShowContentResult()
        {
            return Content("Hello world from Content Result.");
        }

        public ViewResult ShowViewResult()
        {
            return View();
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
    }
}
