using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityResult = Microsoft.AspNetCore.Identity.IdentityResult;

namespace EduHome.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AdminAccountController : Controller
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _SignInManager;
        public AdminAccountController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _SignInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterVm register)
        {

            if (!ModelState.IsValid) return View(register);

            AppUser user = new AppUser
            {
                UserName = register.Username,
                FullName = register.Fullname,
                Email = register.Email
            };
            IdentityResult result = await _userManager.CreateAsync(user, register.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(register);
            }
            return RedirectToAction("Index", "Slider");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginVM login)
        {
            if (!ModelState.IsValid) return View(login);

            AppUser user = await _userManager.FindByNameAsync(login.Username);

            if (user == null)
            {
                ModelState.AddModelError("", "Please enter true data");
                return View(login);
            }

            Microsoft.AspNetCore.Identity.SignInResult result = await _SignInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Please enter true data");
                return View(login);
            }
            return RedirectToAction("Index", "Slider");


        }
        public async Task<IActionResult> LogOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
