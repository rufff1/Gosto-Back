using Gosto.DAL;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Authorization;
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
    public class BlogCategoryController : Controller
    {
        private readonly AppDbContext _context;

        public BlogCategoryController(AppDbContext context)
        {
            _context = context;
        }
      

        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<BlogCategory> blogCategories = _context.BlogCategories.Where(b => b.IsDeleted == false);

            return View(PageNationList<BlogCategory>.Create(blogCategories, pageIndex, 3));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCategory blogCategory)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }




            if (await _context.BlogCategories.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == blogCategory.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {blogCategory.Name} already exists");
                return View(blogCategory);

            }
          
            blogCategory.Name = blogCategory.Name.Trim();
   

            blogCategory.IsDeleted = false;
            blogCategory.CreatAt = DateTime.UtcNow.AddHours(4);
            blogCategory.CreatBy = "System";

            await _context.BlogCategories.AddAsync(blogCategory);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BlogCategory blogCategory = await _context.BlogCategories.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);


            if (blogCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }
            return View(blogCategory);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, BlogCategory blogCategory)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BlogCategory existedBlogCategory = await _context.BlogCategories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (existedBlogCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            if (blogCategory.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            bool isExist = _context.BlogCategories.Any(c => c.Name.ToLower() == blogCategory.Name.ToLower().Trim());
            if (isExist && !((existedBlogCategory.Name.ToLower() == blogCategory.Name.ToLower().Trim())))
            {
                ModelState.AddModelError("", "Bu category artig var");
                return View();
            };

            existedBlogCategory.Name = blogCategory.Name.Trim();
      
            existedBlogCategory.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedBlogCategory.UpdateBy = "System";
            existedBlogCategory.IsDeleted = false;

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");



        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BlogCategory blogCategory = await _context.BlogCategories.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (blogCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(blogCategory);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BlogCategory blogCategory = await _context.BlogCategories
              .Include(c => c.Blogs)
               
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (blogCategory == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (blogCategory.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




            if (blogCategory.Blogs.Count() > 0)
            {
                return Json(new { status = 400 });
            }

            blogCategory.IsDeleted = true;
            blogCategory.DeletedAt = DateTime.UtcNow.AddHours(4);
            blogCategory.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
    }
}

