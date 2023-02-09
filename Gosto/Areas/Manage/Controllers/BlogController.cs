using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Gosto.ViewModels;
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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public BlogController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index(int pageIndex)
        {

            IQueryable<Blog> blogs =  _context.Blogs
                .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.BTag)
                .Where(b => b.IsDeleted == false);

            return View(PageNationList<Blog>.Create(blogs, pageIndex, 3));
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Blog blog = await _context.Blogs
             .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.BTag)
           .FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (blog == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            return View(blog);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {


            ViewBag.BlogCategories = await _context.BlogCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.BTags = await _context.BTags.Where(t => t.IsDeleted == false).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Blog blog)
        {

            ViewBag.BlogCategories = await _context.BlogCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.BTags = await _context.BTags.Where(t => t.IsDeleted == false).ToListAsync();



            if (!ModelState.IsValid)
            {

                return View();
            }

            if (!await _context.BlogCategories.AnyAsync(c => c.IsDeleted == false && c.Id == blog.BlogCategoryId))
            {
                ModelState.AddModelError("CourseCategoryId", "gelen categoriya yalnisdir");
                return View(blog);
            }


            //bos list tuturug secilen taglari elave etmeye asagida elave edirik
            List<BlogTag> blogTags = new List<BlogTag>();

            foreach (int tagId in blog.TagIds)
            {
                if (blog.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "bir tagdan yalniz bir defe secilmelidir");
                    return View(blog);

                }

                if (!await _context.BTags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "secilen tag yalnisdir");
                    return View(blog);
                }

                BlogTag blogTag = new BlogTag
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    BTagId = tagId

                };

                //taglari bos liste add etdik
                blogTags.Add(blogTag);
            }


            if (blog.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!blog.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!blog.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg  tipinnen fayl secin! ");
                return View();
            }


            blog.Image = blog.ImageFile.CreateImage(_env, "assets", "img", "blog");
            blog.BlogTags = blogTags;
            blog.CreatBy = "System";
            blog.IsDeleted = false;
            blog.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Blogs.AddAsync(blog);
            await _context.SaveChangesAsync();



            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {

            ViewBag.BlogCategories = await _context.BlogCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.BTags = await _context.BTags.Where(t => t.IsDeleted == false).ToListAsync();



            if (id == null) return BadRequest("Duzgun Id daxil edin");

            Blog blog = await _context.Blogs
              .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.BTag)
                .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (blog == null) return NotFound("Blog tapilmadi");


            blog.TagIds = await _context.BlogTags.Where(bt => bt.BlogId == id).Select(x => x.BTagId).ToListAsync();
       





            return View(blog);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Blog blog)
        {

            ViewBag.BlogCategories = await _context.BlogCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.BTags = await _context.BTags.Where(t => t.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {

                return View();
            }

            Blog existedBlog = await _context.Blogs
             .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.BTag)
              .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (blog.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            if (existedBlog == null)
            {
                return NotFound("Blog tapilmadi");
            }

            if (id == null) return BadRequest("Id daxil edin");
            _context.BlogTags.RemoveRange(existedBlog.BlogTags);

            List<BlogTag> blogTags = new List<BlogTag>();

            foreach (int tagId in blog.TagIds)
            {
                if (blog.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagIds", "bir tagdan yalniz bir defe secilmelidir");
                    return View(blog);

                }

                if (!await _context.BTags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "secilen tag yalnisdir");
                    return View(blog);
                }

                BlogTag blogTag = new BlogTag
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    BTagId = tagId

                };


                blogTags.Add(blogTag);
            }


            if (blog.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!blog.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!blog.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }


            Helper.DeleteFile(_env, existedBlog.Image, "assets", "img", "Blog");
            existedBlog.Image = blog.ImageFile.CreateImage(_env, "assets", "img", "Blog");
            existedBlog.BlogTags = blogTags;
            existedBlog.Author = blog.Author;
            existedBlog.BlogCategoryId = blog.BlogCategoryId;
            existedBlog.BlogTime = blog.BlogTime;
            existedBlog.Description1 = blog.Description1;
            existedBlog.Description1 = blog.Description1;
            existedBlog.Description3 = blog.Description3;
            existedBlog.Title = blog.Title;
            existedBlog.DescQuota = blog.DescQuota;
            blog.UpdateAt = DateTime.UtcNow.AddHours(4);
            blog.UpdateBy = "System";
            blog.IsDeleted = false;

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


            Blog blog = await _context.Blogs
             .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags).ThenInclude(bt => bt.BTag)
            .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (blog == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (blog.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            blog.IsDeleted = true;
            blog.DeletedAt = DateTime.UtcNow.AddHours(4);
            blog.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }

    }
}
