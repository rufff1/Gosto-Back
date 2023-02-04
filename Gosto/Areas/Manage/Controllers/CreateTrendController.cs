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

    public class CreateTrendController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public CreateTrendController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            CreateTrend createTrend = await _context.CreateTrends.FirstOrDefaultAsync(s => s.IsDeleted == false);

            return View(createTrend);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            CreateTrend createTrend = await _context.CreateTrends.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (createTrend == null) return NotFound("sehife tapilmadi");
            return View(createTrend);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, CreateTrend createTrend)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (createTrend.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            CreateTrend existedCreateTrend = await _context.CreateTrends.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedCreateTrend == null) return NotFound("id tapilmadi");

            if (createTrend.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!createTrend.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!createTrend.ImageFile.CheckFileType("image/jpeg,image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedCreateTrend.BackImage, "assets", "img", "Our-team");
            existedCreateTrend.BackImage = createTrend.ImageFile.CreateImage(_env, "assets", "img", "Our-team");
            existedCreateTrend.Description = createTrend.Description;
            existedCreateTrend.Title = createTrend.Title;
            existedCreateTrend.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedCreateTrend.IsDeleted = false;
            existedCreateTrend.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
