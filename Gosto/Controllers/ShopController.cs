using Gosto.DAL;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {

            ShopVM shopVM = new ShopVM
            {

                ProductCategories = await _context.ProductCategories
              .Include(pt => pt.Products).Where(c => c.IsDeleted == false).ToListAsync(),

                Products = await _context.Products
              .Include(p => p.ProductColors)
              .ThenInclude(p => p.Color)
              .Where(p => p.IsDeleted == false && p.IsSellingProduct).ToListAsync(),
                Brands = await _context.Brands.Where(n => n.IsDeleted == false).ToListAsync(),
                Colors = await _context.Colors.Where(n => n.IsDeleted == false).ToListAsync(),




            };


            int totalPages = (int)Math.Ceiling((decimal)shopVM.Products.Count() / 7);
            if (pageIndex < 1 || pageIndex > totalPages)
            {
                pageIndex = 1;
            }

            shopVM.Products = shopVM.Products.Skip((pageIndex - 1) * 3).Take(8).ToList();
            ViewBag.totalpages = totalPages;
            ViewBag.pageIndex = pageIndex;

            return View(shopVM);
        }


        public async Task<IActionResult> ShopDetail(int? id)
        {

            if (!await _context.Products.AnyAsync(b => b.Id == id))
            {
                return NotFound("Melumat yalnisdir");
            }
            ShopVM shopVM = new ShopVM
            {

                ProductCategories = await _context.ProductCategories
         .Include(pt => pt.Products).Where(c => c.IsDeleted == false).ToListAsync(),
                Products = await _context.Products
         .Include(p => p.ProductColors)
         .ThenInclude(p => p.Color)
         .Include(p=> p.ProductImages)
         .Where(p => p.IsDeleted == false && p.IsSellingProduct).ToListAsync(),
                 Product = await _context.Products
                 .Include(p=> p.ProductTags)
                 .ThenInclude(pt=> pt.PTag)
                 .Include(p=> p.Brand)
                 .Include(p => p.ProductColors)
                  .ThenInclude(p => p.Color)
                 .Include(p => p.ProductImages).FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id),
                  Brands = await _context.Brands.Where(n => n.IsDeleted == false).ToListAsync(),
                Colors = await _context.Colors.Where(n => n.IsDeleted == false).ToListAsync(),
                PTags = await _context.PTags.Where(b => b.IsDeleted == false).ToListAsync(),
                ProductColors = await _context.ProductColors.Where(b => b.IsDeleted == false).ToListAsync(),
                SellingProduct = await _context.Products.Where(p => p.IsDeleted == false && p.IsSellingProduct).Take(4).ToListAsync(),
                TrendingProduct = await _context.Products.Where(p => p.IsDeleted == false && p.IsTrendingProduct).ToListAsync(),
              
            };



            return View(shopVM);
        }

  
    }
}
