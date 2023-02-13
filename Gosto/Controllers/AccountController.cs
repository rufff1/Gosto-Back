using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Identity;
using System.IO;
using System.Net;
using System.Net.Mail;
using Gosto.DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Gosto.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Gosto.Controllers
{
    public class AccountController : Controller
    {

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public readonly IWebHostEnvironment _env;
        private readonly IConfiguration _config;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context, IConfiguration config, IWebHostEnvironment env)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _config = config;
            _env = env;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegstrVM register)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "home");
            }
            AppUser appUser = new AppUser
            {
                
                Name = register.Name,
                UserName = register.Username,
                Email = register.Email,
                isConfirmed = true

            };

            if (!register.TermsAndConditions)
            {
                ModelState.AddModelError("Terms", "Sozlesmeni qebul edin");
                return View();
            }

            string token = Guid.NewGuid().ToString();
            appUser.EmailConfirmationToken = token;



            IdentityResult identityResult = await _userManager.CreateAsync(appUser, register.Password);

            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(appUser, "Member");

            var link = Url.Action(nameof(VerifyEmail), "Account", new { id = appUser.Id, token }, Request.Scheme, Request.Host.ToString());

            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(appUser.Email, "Gosto");
            mail.To.Add(appUser.Email);
            mail.Subject = "VerifyEmail";
            string body = "";
            using (StreamReader reader = new StreamReader("wwwroot/assets/Template/verifyemail.html"))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{link}", link);
           
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = email.Server;
            smtp.Port = email.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
            smtp.Send(mail);
           

            return RedirectToAction(nameof(EmailVerification));

        }
        public IActionResult EmailVerification() => View();



        public async Task<IActionResult> VerifyEmail(string id, string token)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            if (user.EmailConfirmationToken != token)
            {
                return BadRequest();
            }

            var emailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            IdentityResult result = await _userManager.ConfirmEmailAsync(user, emailConfirmationToken);

            if (result.Succeeded)
            {
                string newToken = Guid.NewGuid().ToString();
                user.EmailConfirmationToken = newToken;
                await _userManager.UpdateAsync(user);
                return View();
            }



            return BadRequest();
        }



        public IActionResult ResetPassword() => View();



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM reset)
        {
            if (string.IsNullOrWhiteSpace(reset.Email))
            {
                ModelState.AddModelError(string.Empty, "E-poçt ünvanını daxil edin");
                return View();
            }
            AppUser user = await _userManager.FindByEmailAsync(reset.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Daxil etdiyiniz hesab movcud deyil");
                return View();
            }
            var link = Url.Action(nameof(NewPassword), "Account", new { id = user.Id, token = user.PasswordResetToken }, Request.Scheme, Request.Host.ToString());
            EmailVM email = _config.GetSection("Email").Get<EmailVM>();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(email.SenderEmail, "Gosto");
            mail.To.Add(reset.Email);
            mail.Subject = "Reset Password";
            mail.Body = $"<a href=\"{link}\">Reset Password</a>";
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = email.Server;
            smtp.Port = email.Port;
            smtp.EnableSsl = true;
            smtp.Credentials = new NetworkCredential(email.SenderEmail, email.Password);
            smtp.Send(mail);

            return RedirectToAction(nameof(EmailVerification));
        }


        public IActionResult NewPassword(ResetPasswordVM reset)
        {
            return View(reset);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("NewPassword")]
        public async Task<IActionResult> NewPasswordPost(ResetPasswordVM reset)
        {
            if (!ModelState.IsValid)
            {
                return View(reset);
            }
            if (reset.Id == null)
            {
                return NotFound();
            }
            AppUser user = await _userManager.FindByIdAsync(reset.Id);
            if (user == null)
            {
                return NotFound();
            }
            if (user.PasswordResetToken != reset.Token)
            {
                return BadRequest();
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, reset.Password);



            if (result.Succeeded)
            {
                string passwordResetToken = Guid.NewGuid().ToString();
                user.PasswordResetToken = passwordResetToken;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Login");
            }
            return BadRequest();
        }


        public IActionResult Login()
        {

        


            return View();
        }

        public IActionResult ConfirmByAdmin() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LognVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => u.NormalizedEmail == loginVM.Email.ToUpperInvariant());

            if (appUser == null)
            {
                ModelState.AddModelError("", "E-poçt və ya şifrəniz yanlışdır");
                return View();
            }

            if (!await _userManager.IsEmailConfirmedAsync(appUser))
            {
                ModelState.AddModelError("", "Zəhmət olmasa ilk öncə hesabınızı təsdiqləyin!");
                return View();
            }

            if (appUser.isConfirmed == false)
            {
                return RedirectToAction(nameof(ConfirmByAdmin));
            }

            if (!await _userManager.IsEmailConfirmedAsync(appUser))
            {
                ModelState.AddModelError("", "Zəhmət olmasa ilk öncə hesabınızı təsdiqləyin!");
                return View();
            }

        

            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);

            if (!signInResult.Succeeded)
            {
                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError("", "Hesabınız 10 dəqiqə muddətinə bloklanıb");
                    return View();
                }
                ModelState.AddModelError("", "E-poçt və ya şifrəniz yanlışdır");

                return View();
            }
            await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);
            return RedirectToAction("index", "home");



            //string coockieBasket = HttpContext.Request.Cookies["basket"];

            //if (!string.IsNullOrWhiteSpace(coockieBasket))
            //{
            //    List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(coockieBasket);

            //    List<basket> baskets = new List<Basket>();
            //    List<Basket> existedBasket = await _context.Baskets.Where(b => b.AppUserId == appUser.Id).ToListAsync();
            //    foreach (BasketVM basketVM in basketVMs)
            //    {
            //        if (existedBasket.Any(b => b.ProductId == basketVM.ProductId && b.ColorId == basketVM.ColorId && b.MaterialId == basketVM.MaterialId))
            //        {
            //            existedBasket.Find(b => b.ProductId == basketVM.ProductId && b.ColorId == basketVM.ColorId && b.MaterialId == basketVM.MaterialId).Count = basketVM.Count;
            //        }
            //        else
            //        {
            //            Basket basket = new Basket
            //            {
            //                AppUserId = appUser.Id,
            //                ProductId = basketVM.ProductId,
            //                Count = basketVM.Count,
            //                ColorId = basketVM.ColorId,
            //                MaterialId = basketVM.MaterialId,
            //                CreatedAt = DateTime.UtcNow.AddHours(4)
            //            };

            //            baskets.Add(basket);
            //        }


            //    }

            //    if (baskets.Count > 0)
            //    {
            //        await _context.Baskets.AddRangeAsync(baskets);
            //        await _context.SaveChangesAsync();
            //    }
            //}


        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        

     
    }
}
