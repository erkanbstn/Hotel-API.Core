using ApiConsume.EntityLayer.Concrete;
using Frontend_Mvc.Core.ViewModels.AppUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Frontend_Mvc.Core.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult LogIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel loginViewModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName,loginViewModel.Password,false,false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index","Staff");
            }
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            var appUser = new AppUser()
            {
                Name = registerViewModel.Name,
                Email = registerViewModel.Email,
                UserName = registerViewModel.UserName,
            };
            var result = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("LogIn");
            }
            return View();
        }
        public IActionResult LogOut()
        {
            return View();
        }
    }
}
