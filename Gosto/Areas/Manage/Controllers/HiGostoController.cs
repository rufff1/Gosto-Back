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

    public class HiGostoController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public HiGostoController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            HiGosto hiGosto = await _context.HiGostos.FirstOrDefaultAsync(s => s.IsDeleted == false);

            return View(hiGosto);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            HiGosto hiGosto = await _context.HiGostos.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (hiGosto == null) return NotFound("sehife tapilmadi");
            return View(hiGosto);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, HiGosto hiGosto)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (hiGosto.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            HiGosto existedHiGosto = await _context.HiGostos.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedHiGosto == null) return NotFound("id tapilmadi");

            if (existedHiGosto.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!existedHiGosto.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!existedHiGosto.ImageFile.CheckFileType("image/jpeg,image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedHiGosto.BackImage, "assets", "img", "About");
            existedHiGosto.BackImage = hiGosto.ImageFile.CreateImage(_env, "assets", "img", "About");
            existedHiGosto.Description = hiGosto.Description;
            existedHiGosto.Title = hiGosto.Title;
            existedHiGosto.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedHiGosto.IsDeleted = false;
            existedHiGosto.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
