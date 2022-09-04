using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReverseEnginereeing.Controllers
{
    [Authorize]
    public class PanelController : Controller
    {
        public IActionResult Index() => View();
    }
}
