using Gosto.Areas.ViewModels;
using Gosto.DAL;
using Gosto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.Manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class DashboardController : Controller
    {

 
        private readonly UserManager<AppUser> _userManager;

        private IWebHostEnvironment _env;
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context,IWebHostEnvironment env, UserManager<AppUser> userManager)
        {
            _env = env;
            _userManager = userManager;           
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            DashboardVM dashboardVM = new DashboardVM
            {
                Blogs = await _context.Blogs.Where(b => b.IsDeleted == false).ToListAsync(),
                AppUsers = await _userManager.Users.ToListAsync(),
                SellingProduct = await _context.Products.Where(p => p.IsDeleted == false && p.IsSellingProduct).ToListAsync(),
                Comments = await _context.Comments
                .Include(c => c.AppUser)
                .Include(ca => ca.Blog)
                .Where(c => c.IsDeleted == false).ToListAsync(),
                Product = await _context.Products.FirstOrDefaultAsync(p => p.IsDeleted == false),
            };
            return View(dashboardVM);
        }
    }
}
