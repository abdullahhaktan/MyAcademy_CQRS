using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomerLogin(LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(loginDto);
            }

            ViewBag.role = "Admin";

            return RedirectToAction("Index", "Dashboard", new { area = "User" });
        }

        public async Task<IActionResult> AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminLogin(LoginDto loginDto)
        {
            var result = await signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı!");
                return View("AdminLogin", "Login");
            }

            ViewBag.role = "Admin";
            return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
