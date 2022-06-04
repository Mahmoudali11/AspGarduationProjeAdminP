using AspGraduateProjAdminPan.BL.Helper;
using AspGraduateProjAdminPan.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace AspGraduateProjAdminPan.Controllers
{
     
     public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly ILogger<AccountController> logger;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterationVM model)
        {

            try
            {
                if (ModelState.IsValid)
                {

                    var data = new IdentityUser { UserName = model.Email, Email = model.Email };
                    ///this method hashes password

                    var res = await userManager.CreateAsync(data, model.Password);
                    if (res.Succeeded)
                    {

                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {
                        foreach (var item in res.Errors)
                        {
                            //these errors appear by asp-validation-summary in view
                            ModelState.AddModelError("", item.Description);

                        }


                    }


                }

                return View(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);

            }

        }
        public IActionResult Login()
        {

            if (signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var data = new IdentityUser { Email = model.Email };
                    ///this method hashes password

                    var res = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RemeberMe, false);
                    if (res.Succeeded)
                    {

                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        //foreach (var item in res.Errors)
                        //{
                        //these errors appear by asp-validation-summary in view
                        ModelState.AddModelError("", "Invalid user or password");

                        //}


                    }


                }
                return View(model);



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return View(model);

            }
        }
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordVM model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    //new {} is parameters

                    var passwordResetLink = Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                    MailHelper.Sendmail("GProject,Reset Password ", "Hi this is reset password link dont share it \n" + token);
                    //log events in windows  event viewer
                    logger.Log(LogLevel.Warning, passwordResetLink);

                    return RedirectToAction("ConfirmResetPassword");
                }

                return RedirectToAction("ConfirmResetPassword");

            }

            return View(model);
        }
        public IActionResult ConfirmForgetPassword()
        {
            return View();
        }
        public IActionResult ResetPassword( string Email,string Token)
        {
            if(Email==null|| Token == null)
            {


                ModelState.AddModelError("", "InValid Reset password link");
            }
            return View();
        }  

        [HttpPost]
        public async  Task<IActionResult> ResetPassword(ResetVM model)

        {

            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user != null)
                {
                    var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("ConfirmResetPassword");
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model);
                }

                return RedirectToAction("ConfirmResetPassword");
            }

            return View(model);
        }  
        public IActionResult ConfirmResetPassword()
        {
            return View();
        }   
        public async Task< IActionResult> LogOut()
        {
         await   signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }

    }
}
