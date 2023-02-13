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
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;


        public BlogController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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
                .Include(b => b.Comments)
                .ThenInclude(c => c.AppUser)
                .FirstOrDefaultAsync(b=> b.IsDeleted == false && b.Id == id),
                BlogCategories = await _context.BlogCategories.Include(b=> b.Blogs).Where(b=> b.IsDeleted == false).ToListAsync(),
                BTags = await _context.BTags.Where(b=> b.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs
                .Include(b => b.Comments)
                .ThenInclude(c => c.AppUser)
                .Where(b=> b.IsDeleted == false).Take(3).ToListAsync(),
              

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

        public async Task<IActionResult> AddComment(string Subject, string Message, int BlogId)
        {
            //return Json(Subject);
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return Json(StatusCode(400));

            Comment cmnt = new Comment
            {
                AppUserId = user.Id,
                BlogId = BlogId,
                CreatedTime = DateTime.Now,
                Message = Message,
                Subject = Subject,
                IsAccepted = true
            };
            _context.Comments.Add(cmnt);
            _context.SaveChanges();
            BlogVM blog = new BlogVM
            {
                Blog = _context.Blogs.Include(b => b.Comments).ThenInclude(b => b.Blog).FirstOrDefault(b => b.Id == BlogId)
            };


            return PartialView("_BlogCommentPartialView", blog);


        }


        public async Task<IActionResult> DeleteComment(int id)
        {
            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid) return RedirectToAction("Details", "Blog");
            if (!_context.Comments.Any(c => c.Id == id && c.AppUserId == user.Id)) return NotFound();
            Comment comment = _context.Comments.FirstOrDefault(c => c.Id == id && c.AppUserId == user.Id);
            BlogVM BlogVM = new BlogVM
            {
                Blog = _context.Blogs.Include(e => e.Comments).ThenInclude(c => c.AppUser).FirstOrDefault()
            };
            _context.Comments.Remove(comment);
            _context.SaveChanges();

            return Json(new { status = 200 });




        }
    }
}
