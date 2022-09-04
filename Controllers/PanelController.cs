using Microsoft.AspNetCore.Mvc;

namespace ReverseEnginereeing.Controllers
{
    public class PanelController : Controller
    {
        //[Authorize]
        public IActionResult Index() => View();
        
    }
}
