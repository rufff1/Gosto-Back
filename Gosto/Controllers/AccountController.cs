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
using Gosto.Extensions;
using Microsoft.AspNetCore.Authorization;
using Gosto.Helpers;

namespace Gosto.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IWebHostEnvironment _env;
        private readonly AppDbContext _context;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IWebHostEnvironment env, AppDbContext context)
        {
            _roleManager = roleManager;
            _signInManager = signInManager;
            _userManager = userManager;
            _env = env;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegstrVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new AppUser
            {
                Name = registerVM.Name,
                UserName = registerVM.Username,
                Email = registerVM.Email,
                Job = registerVM.Job,
                Country = registerVM.Country,
                Adress = registerVM.Adress,
                Phone = registerVM.Phone
            };

   



            if (!registerVM.UserImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("UserImageFile", "Seçilmiş faylın tipi jpeg olmalıdır");
                return View();
            }
            if (!registerVM.UserImageFile.CheckFileSize(100))
            {
                ModelState.AddModelError("UserImageFile", "Secilmiş şəklin həcmi 100KB-dan artıq ola bilməz");
                return View();
            }
            appUser.UserImageFile = registerVM.UserImageFile;
            appUser.UserImage = appUser.UserImageFile.CreateImage(_env, "manage", "img", "user");


            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerVM.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var item in identityResult.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }

            


            await _userManager.AddToRoleAsync(appUser, "Member");
            return RedirectToAction("login");


        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LognVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Email ve ya Paswoord duzgun qeyd edin");
                return View(loginVM);
            }
            Microsoft.AspNetCore.Identity.SignInResult signInResult = await _signInManager.CheckPasswordSignInAsync(appUser, loginVM.Password, true);
            if (signInResult.IsLockedOut)
            {
                ModelState.AddModelError("", "Sifreni 3 defeden artig sehf yigdiginiz ucun bloklandiniz");
                return View(loginVM);
            }
            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError("", "Email ve ya Paswoord duzgun qeyd edin");
                return View(loginVM);
            }
            await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ProfleVM profileVM = new ProfleVM
            {
                Name = appUser.Name,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Job = appUser.Job,
                Adress = appUser.Adress,
                Country = appUser.Country,
                Phone = appUser.Phone,
                UserImage = appUser.UserImage,


            };


            return View(profileVM);
        }





        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ProfileEdit()
        {
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            ProfleVM profileVM = new ProfleVM
            {
                Name = appUser.Name,
                UserName = appUser.UserName,
                Email = appUser.Email,
                Job = appUser.Job,
                Adress = appUser.Adress,
                Country = appUser.Country,
                Phone = appUser.Phone,
                UserImage = appUser.UserImage,


            };


            return View(profileVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ProfileEdit(ProfleVM profileVM)
        {
            if (!ModelState.IsValid)
            {
                return View(profileVM);
            }
            bool check = false;

            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (appUser.Name.ToLowerInvariant() != profileVM.Name.Trim().ToLowerInvariant())
            {
                check = true;
                appUser.Name = profileVM.Name.Trim();

            }
            if (appUser.NormalizedUserName != profileVM.UserName.Trim().ToUpperInvariant())
            {
                check = true;
                appUser.UserName = profileVM.UserName.Trim();

            }
            if (appUser.NormalizedEmail != profileVM.Email.Trim().ToLowerInvariant())
            {
                check = true;
                appUser.Email = profileVM.Email.Trim();

            }
            if (appUser.Phone != profileVM.Phone.Trim().ToLowerInvariant())
            {
                check = true;
                appUser.Email = profileVM.Email.Trim();

            }
            profileVM.UserImage = appUser.UserImage;

       
            if (!profileVM.UserImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("UserImageFile", "Seçilmiş faylın tipi jpeg olmalıdır");
                return View();
            }
            if (!profileVM.UserImageFile.CheckFileSize(100))
            {
                ModelState.AddModelError("UserImageFile", "Secilmiş şəklin həcmi 100KB-dan artıq ola bilməz");
                return View();
            }
            if (appUser.UserImage != null)
            {
                Helper.DeleteFile(_env, appUser.UserImage, "manage", "img", "user");
            }
            appUser.UserImage = profileVM.UserImageFile.CreateImage(_env, "manage", "img", "user");



            if (check)
            {
                appUser.UserName = profileVM.UserName;
                appUser.Job = profileVM.Job;
                appUser.Adress = profileVM.Adress;
                appUser.Country = profileVM.Country;
                appUser.Phone = profileVM.Phone;

                IdentityResult identityResult = await _userManager.UpdateAsync(appUser);
                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(profileVM);
                }
            }
            if (!string.IsNullOrWhiteSpace(profileVM.CurrentPaswoord))
            {
                if (!await _userManager.CheckPasswordAsync(appUser, profileVM.CurrentPaswoord))
                {
                    ModelState.AddModelError("CurrentPaswoord", "Sifrenizi duzgun daxil edin");
                    return View(profileVM);

                }
                if (profileVM.NewPaswoord == profileVM.CurrentPaswoord)
                {
                    ModelState.AddModelError("NewPaswoord", "Yeni Sifrenizle hal-hazirdaki eynidir");
                    return View(profileVM);

                }

                string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);
                IdentityResult identityResult = await _userManager.ResetPasswordAsync(appUser, token, profileVM.NewPaswoord);

                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View(profileVM);

                }
            }





            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }








    }
}
