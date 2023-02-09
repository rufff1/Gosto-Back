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
    public class ColorController : Controller
    {
        private readonly AppDbContext _context;

        public ColorController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<Color> colors =  _context.Colors.Where(c => c.IsDeleted == false);

            return View(PageNationList<Color>.Create(colors, pageIndex, 3));
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Color color)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }




            if (await _context.Colors.AnyAsync(c => c.IsDeleted == false && c.Name.ToLower() == color.Name.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {color.Name} already exists");
                return View(color);

            }
            if (await _context.Colors.AnyAsync(c => c.IsDeleted == false && c.HTax.ToLower() == color.HTax.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This htax {color.HTax} already exists");
                return View(color);

            }
            color.Name = color.Name.Trim();
            color.HTax = color.HTax.Trim();

            color.IsDeleted = false;
            color.CreatAt = DateTime.UtcNow.AddHours(4);
            color.CreatBy = "System";

            await _context.Colors.AddAsync(color);
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

            Color color = await _context.Colors.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);


            if (color == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }
            return View(color);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Color color)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Color existedColor = await _context.Colors.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (existedColor == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            if (color.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            bool isExist = _context.Colors.Any(c => c.Name.ToLower() == color.Name.ToLower().Trim() && c.HTax.ToLower() == color.HTax.ToLower().Trim());
            if (isExist && !((existedColor.Name.ToLower() == color.Name.ToLower().Trim()) && (existedColor.HTax.ToLower() == color.HTax.ToLower().Trim())))
            {
                ModelState.AddModelError("", "Bu reng artig var");
                return View();
            };

            existedColor.Name = color.Name.Trim();
            existedColor.HTax = color.HTax.Trim();
            color.UpdateAt = DateTime.UtcNow.AddHours(4);
            color.UpdateBy = "System";
            color.IsDeleted = false;

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

            Color color = await _context.Colors.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (color == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(color);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {


            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Color color = await _context.Colors
              .Include(c => c.ProductColors)
               .ThenInclude(b => b.Product)
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (color == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (color.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }




          

            color.IsDeleted = true;
            color.DeletedAt = DateTime.UtcNow.AddHours(4);
            color.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }
    }
}
