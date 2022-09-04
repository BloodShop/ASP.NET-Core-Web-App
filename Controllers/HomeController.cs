using Microsoft.AspNetCore.Mvc;

namespace ReverseEnginereeing.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
        public IActionResult Cities() => View();
    }
}
