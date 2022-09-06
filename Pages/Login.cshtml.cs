using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReverseEnginereeing.Data;
using ReverseEnginereeing.ViewModels;

namespace ReverseEnginereeing.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }

        readonly SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            this._signInManager = signInManager;
        }

        public void OnGet()
        { }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync(string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, lockoutOnFailure: false).ConfigureAwait(false);
                if (identityResult.Succeeded)
                {
                    if (returnUrl == null || returnUrl == "/")
                        return RedirectToPage("Index");
                    else
                        return RedirectToPage(returnUrl);
                }
                ModelState.AddModelError("", "Username or password incorrect");
            }
            return Page();
        }
    }
}