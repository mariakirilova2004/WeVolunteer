﻿using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using WeVolunteer.Core.Constants;
using WeVolunteer.Core.Services.User;
using WeVolunteer.Infrastructure.Data.Entities.Account;
using WeVolunteer.Core.Models.User;

namespace WeVolunteer.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IUserService userService;

        public UserController(
            UserManager<User> _userManager,
            SignInManager<User> _signInManager, 
            IUserService _userService)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            this.userService = _userService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already registered!";
                return RedirectToAction("Index", "Home");
            }
            var model = new UserRegisterViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            var sanitalizer = new HtmlSanitizer();

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid registration";
                return View(model);
            }

            if (userManager.Users.Any(u => u.Email == model.Email))
            {
                TempData[MessageConstant.ErrorMessage] = "Тhere is a user with this email";
                return View(model);
            }

            var user = new User()
            {
                FirstName = sanitalizer.Sanitize(model.FirstName),
                LastName = sanitalizer.Sanitize(model.LastName),
                Email = sanitalizer.Sanitize(model.Email),
                PhoneNumber = sanitalizer.Sanitize(model.PhoneNumber),
                BirthDate = model.BirthDate,
                UserName = sanitalizer.Sanitize(model.Username)
            };

            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                TempData[MessageConstant.SuccessMessage] = "Your account has been successfully registered";
                return RedirectToAction("Login", "User");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }

            TempData[MessageConstant.WarningMessage] = "Something went wrong!";
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already logged in";
                return RedirectToAction("Index", "Home");
            }

            var model = new UserLoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            if (User?.Identity?.IsAuthenticated ?? false)
            {
                TempData[MessageConstant.WarningMessage] = "You have already logged in";
                return RedirectToAction("Index", "Home");
            }

            if (!ModelState.IsValid)
            {
                TempData[MessageConstant.ErrorMessage] = "Invalid login";
                return View(model);
            }

            var user = userManager.Users.First(u => u.Email == model.Email);

            if (user != null)
            {
                var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                if (result.Succeeded)
                {
                    TempData[MessageConstant.SuccessMessage] = "You have successfully logged in";
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError("", "Invalid login");
            TempData[MessageConstant.ErrorMessage] = "Invalid login";

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            TempData[MessageConstant.SuccessMessage] = "You have successfully logged out";
            return RedirectToAction("Index", "Home");
        }
    }
}
