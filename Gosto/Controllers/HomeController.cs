using Gosto.DAL;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(),
                ProductCategories = await _context.ProductCategories.Where(c => c.IsDeleted == false).ToListAsync(),
                Teams = await _context.Teams.Where(t => t.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs
                .Include(b=> b.BlogCategory)
                .Where(b => b.IsDeleted == false).ToListAsync(),
                SellingProduct = await _context.Products.Where(p => p.IsDeleted == false && p.IsSellingProduct).Take(8).ToListAsync(),
                TrendingProduct = await _context.Products.Where(p => p.IsDeleted == false && p.IsTrendingProduct).ToListAsync(),


            };


            return View(homeVM);
        }
    }
}
