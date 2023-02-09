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
    public class PTagController : Controller
    {
        private readonly AppDbContext _context;

        public PTagController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<PTag> pTags =  _context.PTags.Where(c => c.IsDeleted == false);

            return View(PageNationList<PTag>.Create(pTags, pageIndex, 3));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PTag pTag)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }



            if (pTag.Name == null)
            {
                ModelState.AddModelError("Name", "Tag adi daxil edin");
                return View(pTag);

            }
            if (await _context.PTags.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == pTag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {pTag.Name} already exists");
                return View(pTag);

            }
            pTag.Name = pTag.Name.Trim();
            pTag.IsDeleted = false;
            pTag.CreatAt = DateTime.UtcNow.AddHours(4);
            pTag.CreatBy = "System";

            await _context.PTags.AddAsync(pTag);
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

            PTag pTag = await _context.PTags.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);


            if (pTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }
            return View(pTag);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, PTag pTag)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            PTag existedPtag = await _context.PTags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (existedPtag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            if (pTag.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            if (pTag.Name == null)
            {
                ModelState.AddModelError("Name", "tag adi daxil edin");
                return View(pTag);

            }
            bool isExist = _context.PTags.Any(c => c.Name.ToLower() == pTag.Name.ToLower().Trim());
            if (isExist && !(existedPtag.Name.ToLower() == pTag.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", "Bu adla Blog Tag var");
                return View();
            };

            existedPtag.Name = pTag.Name.Trim();
            pTag.UpdateAt = DateTime.UtcNow.AddHours(4);
            pTag.UpdateBy = "System";
            pTag.IsDeleted = false;

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

            PTag pTag = await _context.PTags.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (pTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(pTag);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            PTag pTag = await _context.PTags
              .Include(c => c.ProductTags)
               .ThenInclude(b => b.Product)
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (pTag == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (pTag.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




          

            pTag.IsDeleted = true;
            pTag.DeletedAt = DateTime.UtcNow.AddHours(4);
            pTag.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
    }
}
