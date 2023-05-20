using ApiConsume.EntityLayer.Concrete;
using Frontend_Mvc.Core.ViewModels.AppUser;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using static Org.BouncyCastle.Crypto.Engines.SM2Engine;

namespace Frontend_Mvc.Core.Controllers
{
    [AllowAnonymous]
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
            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                MimeMessage mime = new MimeMessage();
                MailboxAddress mailboxfrom = new MailboxAddress("RapidAdmin", "profesyonel59@gmail.com");
                MailboxAddress mailboxto = new MailboxAddress("User", loginViewModel.Email);
                mime.From.Add(mailboxfrom);
                mime.To.Add(mailboxto);
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Hesabınızda Şu Tarihte Giriş Yapıldı : {Convert.ToDateTime(DateTime.Now).ToString("dd/MM/yyyy")}";
                mime.Body = bodyBuilder.ToMessageBody();
                mime.Subject = "API Projesi Giriş Bildirimi";
                SmtpClient client = new SmtpClient();
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("profesyonel59@gmail.com", "biiqkczqygkjgtnm");
                client.Send(mime);
                client.Disconnect(true);
                return RedirectToAction("Index", "Staff");
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
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("LogIn");
        }
    }
}
