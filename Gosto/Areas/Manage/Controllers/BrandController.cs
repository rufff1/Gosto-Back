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
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult>  Index()
        {
            IEnumerable<Brand> brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            return View(brands);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {

            if (!ModelState.IsValid)
            {

                return View(brand);
            }

            if (brand.Name == null)
            {
                ModelState.AddModelError("Name", "brand adi daxil edin");
                return View(brand);

            }
         
            
            if (await _context.Brands.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == brand.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {brand.Name} already exists");
                return View(brand);

            }

            if (brand.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!brand.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!brand.ImageFile.CheckFileType("image/"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }


            brand.Image = brand.ImageFile.CreateImage(_env, "assets", "img", "brand");
            brand.CreatBy = "System";
            brand.IsDeleted = false;
            brand.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id==null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b=> b.IsDeleted==false && b.Id == id);

            if (brand==null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(brand);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Brand brand = await _context.Brands.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (brand == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id , Brand brand)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (brand.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Brand existedBrand = await _context.Brands.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (existedBrand == null) return NotFound("id tapilmadi");

            if (brand.Name == null)
            {
                ModelState.AddModelError("Name", "brand adi daxil edin");
                return View(brand);

            }

            bool isExist = _context.Brands.Any(c => c.Name.ToLower() == brand.Name.ToLower().Trim());
            if (isExist && !(existedBrand.Name.ToLower() == brand.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Bu adla Brand var");
                return View();
            };


            if (existedBrand == null) return NotFound("id tapilmadi");

            if (brand.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!brand.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!brand.ImageFile.CheckFileType("image/jpeg,image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedBrand.Image, "assets", "img", "brand");
            existedBrand.Image = brand.ImageFile.CreateImage(_env, "assets", "img", "brand");
            existedBrand.BrandInfo = brand.BrandInfo;
            existedBrand.Name = brand.Name;
            brand.UpdateAt = DateTime.UtcNow.AddHours(4);
            brand.IsDeleted = false;
            brand.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id )
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Brand brand = await _context.Brands
    .Include(c => c.Products)
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (brand == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (brand.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




            if (brand.Products.Count() > 0)
            {
                return BadRequest();
            }

            brand.IsDeleted = true;
            brand.DeletedAt = DateTime.UtcNow.AddHours(4);
            brand.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = 200 });
        }
    }
}
