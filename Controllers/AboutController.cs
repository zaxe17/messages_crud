using Microsoft.AspNetCore.Mvc;

namespace mvc_example.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
