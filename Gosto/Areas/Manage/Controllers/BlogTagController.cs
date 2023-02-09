using Gosto.DAL;
using Gosto.Models;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.Manage.Controllers
{
    [Area("manage")]
    public class BlogTagController : Controller
    {
        private readonly AppDbContext _context;

        public BlogTagController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index(int pageIndex)
        {
            IQueryable<BTag> bTags = _context.BTags.Where(c => c.IsDeleted == false);

            return View(PageNationList<BTag>.Create(bTags, pageIndex, 3));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BTag bTag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            if (bTag.Name == null)
            {
                ModelState.AddModelError("Name", "Tag adi daxil edin");
                return View(bTag);

            }
            if (await _context.BTags.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == bTag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {bTag.Name} already exists");
                return View(bTag);

            }
            bTag.Name = bTag.Name.Trim();
            bTag.IsDeleted = false;
            bTag.CreatAt = DateTime.UtcNow.AddHours(4);
            bTag.CreatBy = "System";

            await _context.BTags.AddAsync(bTag);
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

            BTag bTag = await _context.BTags.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);


            if (bTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }
            return View(bTag);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, BTag bTag)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BTag existedbTag = await _context.BTags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (existedbTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            if (bTag.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            if (bTag.Name == null)
            {
                ModelState.AddModelError("Name", "tag adi daxil edin");
                return View(bTag);

            }
            bool isExist = _context.BTags.Any(c => c.Name.ToLower() == bTag.Name.ToLower().Trim());
            if (isExist && !(existedbTag.Name.ToLower() == bTag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Bu adla Blog Tag var");
                return View();
            };

            existedbTag.Name = bTag.Name.Trim();
            bTag.UpdateAt = DateTime.UtcNow.AddHours(4);
            bTag.UpdateBy = "System";
            bTag.IsDeleted = false;

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

            BTag bTag = await _context.BTags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (bTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(bTag);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            BTag bTag = await _context.BTags
              .Include(c => c.BlogTags)
               .ThenInclude(b=> b.Blog)        
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (bTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (bTag.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




            if (bTag.BlogTags.Count() > 0)
            {
                return Json(new { status = 400 });
            }

            bTag.IsDeleted = true;
            bTag.DeletedAt = DateTime.UtcNow.AddHours(4);
            bTag.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
    }
}
