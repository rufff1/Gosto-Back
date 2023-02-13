using Gosto.DAL;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public ContactController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult>  Index()
        {

            Location location = await _context.Locations.FirstOrDefaultAsync(w => w.IsDeleted == false);
           

          
            return View(location);
        }


    }
}
