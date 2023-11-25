using Microsoft.AspNetCore.Mvc;

namespace PollApi.Controllers.MVC
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
