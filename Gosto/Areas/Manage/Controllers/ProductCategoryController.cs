using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.Manage.Controllers
{
    [Area("manage")]

    public class ProductCategoryController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public ProductCategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductCategory> productCategories = await _context.ProductCategories.Where(b => b.IsDeleted == false).ToListAsync();
            return View(productCategories);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCategory productCategory)
        {

            if (!ModelState.IsValid)
            {

                return View(productCategory);
            }

            if (productCategory.Name == null)
            {
                ModelState.AddModelError("Name", "category adi daxil edin");
                return View(productCategory);

            }


            if (await _context.ProductCategories.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == productCategory.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {productCategory.Name} already exists");
                return View(productCategory);

            }

            if (productCategory.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!productCategory.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!productCategory.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image  jpeg tipinnen fayl secin! ");
                return View();
            }


            productCategory.Image = productCategory.ImageFile.CreateImage(_env, "assets", "img", "Category");
            productCategory.CreatBy = "System";
            productCategory.IsDeleted = false;
            productCategory.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            ProductCategory productCategory = await _context.ProductCategories.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (productCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(productCategory);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            ProductCategory productCategory = await _context.ProductCategories.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (productCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(productCategory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, ProductCategory productCategory)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (productCategory.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            ProductCategory existedProductCategory = await _context.ProductCategories.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (existedProductCategory == null) return NotFound("id tapilmadi");

            if (productCategory.Name == null)
            {
                ModelState.AddModelError("Name", "category adi daxil edin");
                return View(productCategory);

            }

            bool isExist = _context.ProductCategories.Any(c => c.Name.ToLower() == productCategory.Name.ToLower().Trim());
            if (isExist && !(existedProductCategory.Name.ToLower() == productCategory.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Bu adla category var");
                return View();
            };


            if (existedProductCategory == null) return NotFound("id tapilmadi");

            if (productCategory.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!productCategory.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!productCategory.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image  jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedProductCategory.Image, "assets", "img", "Category");
            existedProductCategory.Image = productCategory.ImageFile.CreateImage(_env, "assets", "img", "Category");
            existedProductCategory.Name = productCategory.Name;
           
          
            existedProductCategory.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedProductCategory.IsDeleted = false;
            existedProductCategory.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            ProductCategory productCategory = await _context.ProductCategories
    .Include(c => c.Products)
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (productCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (productCategory.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




            if (productCategory.Products.Count() > 0)
            {
                return BadRequest();
            }

            productCategory.IsDeleted = true;
            productCategory.DeletedAt = DateTime.UtcNow.AddHours(4);
            productCategory.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = 200 });
        }
    }
}
