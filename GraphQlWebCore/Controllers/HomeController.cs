using Microsoft.AspNetCore.Mvc;

namespace GraphQlWebCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}