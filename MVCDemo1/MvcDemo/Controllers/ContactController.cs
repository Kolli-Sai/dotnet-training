using Microsoft.AspNetCore.Mvc;

namespace MVCDemo1.Controllers
{
    public class ContactController : Controller
    {
        public ContentResult ShowContentResult()
        {
            return Content("Hello world from Content Result.");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
