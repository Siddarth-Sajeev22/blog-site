using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using BlogSite.Models;
using Microsoft.Extensions.Options;

namespace BlogSite.Controllers
{
    public class AuthController : Controller
    {
        private readonly AdminCredentials _credentials; 

        public AuthController(IOptions<AdminCredentials> options)
        {
            _credentials = options.Value; 
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Username == _credentials.Username && model.Password == _credentials.Password)
            {
                // Create claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username)
                };

                // Create identity
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Sign in
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

                return RedirectToAction("Index", "Admin");
            }

            ViewBag.Error = "Invalid username or password.";
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        public IActionResult AccessDenied() => View();
    }
}
