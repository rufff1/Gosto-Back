using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class OurTeamController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public OurTeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            OurTeam ourTeam = await _context.OurTeams.FirstOrDefaultAsync(s => s.IsDeleted == false);

            return View(ourTeam);

        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            OurTeam ourTeam = await _context.OurTeams.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (ourTeam == null) return NotFound("sehife tapilmadi");
            return View(ourTeam);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, OurTeam ourTeam)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (ourTeam.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            OurTeam existedOurTeam = await _context.OurTeams.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedOurTeam == null) return NotFound("id tapilmadi");

            if (existedOurTeam.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!existedOurTeam.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!existedOurTeam.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedOurTeam.BackImage, "assets", "img", "Our-team");
            existedOurTeam.BackImage = ourTeam.ImageFile.CreateImage(_env, "assets", "img", "Our-team");
            existedOurTeam.Description = ourTeam.Description;
            existedOurTeam.Title = ourTeam.Title;
            existedOurTeam.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedOurTeam.IsDeleted = false;
            existedOurTeam.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
