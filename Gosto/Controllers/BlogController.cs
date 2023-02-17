using Gosto.DAL;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Authorization;
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

            BlogVM blogVM = new BlogVM
            {
                Blog = await _context.Blogs
            .Include(b => b.BlogCategory)
            .Include(b => b.BlogTags)
            .ThenInclude(bt => bt.BTag)

            .FirstOrDefaultAsync(b => b.IsDeleted == false),
                BlogCategories = await _context.BlogCategories.Include(b => b.Blogs).Where(b => b.IsDeleted == false).ToListAsync(),
                BTags = await _context.BTags.Where(b => b.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs
         
            .Where(b => b.IsDeleted == false).ToListAsync(),


            };

            int totalPages = (int)Math.Ceiling((decimal)blogVM.Blogs.Count() / 7);
            if (pageIndex < 1 || pageIndex > totalPages)
            {
                pageIndex = 1;
            }

            blogVM.Blogs = blogVM.Blogs.Skip((pageIndex - 1) * 3).Take(8).ToList();
            ViewBag.totalpages = totalPages;
            ViewBag.pageIndex = pageIndex;

            return View(blogVM);
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
                .Include(b => b.BlogCategory)
                .Include(b => b.BlogTags)
                .ThenInclude(bt => bt.BTag)
                .Include(b => b.Comments)
                .ThenInclude(c => c.AppUser)
                .FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id),
        

            };


            return View(blogVM);
        }


        public async Task<IActionResult> CategoryFindBlog(int? id)
        {
            BlogVM blogVM = new BlogVM
            {

                BlogCategories = await _context.BlogCategories.Include(b => b.Blogs).Where(b => b.IsDeleted == false).ToListAsync(),
                BTags = await _context.BTags.Where(b => b.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs
          .Include(b => b.BlogCategory)
          .Include(b => b.BlogTags)
          .ThenInclude(bt => bt.BTag)
          .Where(b => b.IsDeleted == false && b.BlogCategoryId == id).ToListAsync(),


            };

           



            if (blogVM.Blogs.Count() < 1)
            {
                return NotFound("Bu categoriyaya aid blog tapilmadi");
            }

            if (blogVM.Blogs == null)
            {
                return NotFound("Id tapilmadi");
            }

            return View(blogVM);
        }


        public async Task<IActionResult> TagFindBlog(int? id)
        {

            BlogVM blogVM = new BlogVM
            {

                BlogCategories = await _context.BlogCategories.Include(b => b.Blogs).Where(b => b.IsDeleted == false).ToListAsync(),
                BTags = await _context.BTags.Where(b => b.IsDeleted == false).ToListAsync(),
                Blogs = await _context.Blogs
        .Include(b => b.BlogCategory)
        .Include(b => b.BlogTags)
        .ThenInclude(bt => bt.BTag)
        .Where(b => b.IsDeleted == false && b.BlogTags.Any(bt => bt.BTagId == id)).ToListAsync(),


            };



            if (blogVM.Blogs.Count() < 1)
            {
                return NotFound("Bu taga aid blog tapilmadi");
            }

            if (blogVM.Blogs == null)
            {
                return NotFound("Id tapilmadi");
            }


            return View(blogVM);
        }


        public async Task<IActionResult> Search(int? id, string search)
        {


            IEnumerable<SearchVM> products = await _context.Products
               .Where
               (p => id != null ? p.ProductCategoryId == id : true
              && p.Title.ToLower().Contains(search.ToLower())
                  || p.Brand.Name.ToLower().Contains(search.ToLower()))
               .OrderByDescending(p => p.Id)
               .Take(3)
                  .Select(x => new SearchVM
                  {
                      Id = x.Id,
                      Name = x.Title,
                      Image = x.MainImage,
                      Price = x.Price
                  })
                  .ToListAsync();


            return View("_SearchPartialView", products);
        }


        [Authorize]
        [AutoValidateAntiforgeryToken]
        [HttpPost]

        public async Task<IActionResult> AddComment(Comment comment)
        {
        
     
        

            AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
            //if (!ModelState.IsValid) return RedirectToAction("BlogDetail", "Blog", new { id = comment.BlogId });
            if (!_context.Blogs.Any(f => f.Id == comment.BlogId)) return NotFound();
            Comment cmnt = new Comment
            {
                Message = comment.Message,
            
                BlogId = comment.BlogId,
                CreatAt = DateTime.Now,
                AppUserId = user.Id,
                IsAccepted = true,
            };
            _context.Comments.Add(cmnt);
            _context.SaveChanges();
            return RedirectToAction("BlogDetail", "Blog", new { id = comment.BlogId });


        }

        [Authorize]
    
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
