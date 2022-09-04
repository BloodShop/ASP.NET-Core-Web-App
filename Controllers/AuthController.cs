using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReverseEnginereeing.ViewModel;

namespace ReverseEnginereeing.Controllers
{
    public class AuthController : Controller
    {
        SignInManager<IdentityUser> _signInManager; // Handles all the sign ins

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
