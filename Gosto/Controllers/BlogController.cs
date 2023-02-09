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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;

        public BlogController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<Blog> blogs = _context.Blogs.Where(b => b.IsDeleted == false);

            return View(PageNationList<Blog>.Create(blogs, pageIndex, 6));
        }

        public async Task<IActionResult> BlogDetail (int? id)
        {

            if (!await _context.Blogs.AnyAsync(b => b.Id == id))
            {
                return NotFound("Melumat yalnisdir");
            }

            BlogVM blogVM = new BlogVM
            {
                Blog = await _context.Blogs
                .Include(b=> b.BlogCategory)
                .Include(b=> b.BlogTags)
                .ThenInclude(bt=> bt.BTag)
                .FirstOrDefaultAsync(b=> b.IsDeleted == false && b.Id == id),
                BlogCategories = await _context.BlogCategories.Include(b=> b.Blogs).Where(b=> b.IsDeleted == false).ToListAsync(),
                BTags = await _context.BTags.Where(b=> b.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs.Where(b=> b.IsDeleted == false).Take(3).ToListAsync()
            };


            return View(blogVM);
        }


        public async Task<IActionResult> CategoryFindBlog(int? id)
        {



            IEnumerable<Blog> blogs = await _context.Blogs
                 .Include(b => b.BlogCategory)
                 .Where(b => b.IsDeleted == false && b.BlogCategoryId == id).ToListAsync();

            if (blogs.Count() < 1)
            {
                return NotFound("Bu categoriyaya aid blog tapilmadi");
            }

            if (blogs == null)
            {
                return NotFound("Id tapilmadi");
            }

            return View(blogs);
        }


        public async Task<IActionResult> TagFindBlog(int? id)
        {

            List<Blog> blogs = await _context.Blogs
                .Include(b => b.BlogTags)
                .ThenInclude(bt => bt.BTag)
                .Where(b => b.IsDeleted == false && b.BlogTags.Any(bt => bt.BTagId == id)).ToListAsync();


            if (blogs.Count() < 1)
            {
                return NotFound("Bu taga aid blog tapilmadi");
            }

            if (blogs == null)
            {
                return NotFound("Id tapilmadi");
            }


            return View(blogs);
        }


        public async Task<IActionResult> Search(int? id, string search)
        {


            IEnumerable<SearchVM> blogs = await _context.Blogs
                .Where(c => c.Title.ToLower().Contains(search.ToLower()))
                .OrderByDescending(p => p.Id)
                .Take(3)
                   .Select(x => new SearchVM
                   {
                       Id = x.Id,
                       Name = x.Title,
                       Image = x.Image
                   })
                   .ToListAsync();


            return View("_BlogSearchPartialView", blogs);
        }
    }
}
