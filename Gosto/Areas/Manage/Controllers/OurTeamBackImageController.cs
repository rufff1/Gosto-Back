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

    public class OurTeamBackImageController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public OurTeamBackImageController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            OurTeamBackImage ourTeamBackImage = await _context.OurTeamBackImages.FirstOrDefaultAsync(s => s.IsDeleted == false);

            return View(ourTeamBackImage);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            OurTeamBackImage ourTeamBackImage = await _context.OurTeamBackImages.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (ourTeamBackImage == null) return NotFound("sehife tapilmadi");
            return View(ourTeamBackImage);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, OurTeamBackImage ourTeamBackImage)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (ourTeamBackImage.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            OurTeamBackImage existedOurTeamBackImage = await _context.OurTeamBackImages.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedOurTeamBackImage == null) return NotFound("id tapilmadi");

            if (existedOurTeamBackImage.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!existedOurTeamBackImage.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!existedOurTeamBackImage.ImageFile.CheckFileType("image/jpeg,image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedOurTeamBackImage.Image, "assets", "img", "Our-team");
            existedOurTeamBackImage.Image = ourTeamBackImage.ImageFile.CreateImage(_env, "assets", "img", "Our-team");
            
            existedOurTeamBackImage.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedOurTeamBackImage.IsDeleted = false;
            existedOurTeamBackImage.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
