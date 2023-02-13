using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Gosto.ViewModels;
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
    public class LocationController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public LocationController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<Location> locations =  _context.Locations.Where(b => b.IsDeleted == false);
            return View(PageNationList<Location>.Create(locations, pageIndex, 3));
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Location location)
        {

            if (!ModelState.IsValid)
            {

                return View(location);
            }

           


            if (await _context.Locations.AnyAsync(c => c.IsDeleted == false && c.Title.ToLower() == location.Title.ToLower().Trim() && c.Adress.ToLower() == location.Adress.ToLower().Trim()))
            {
                ModelState.AddModelError("Name", $"This name {location.Adress} already exists");
                return View(location);

            }

            if (location.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!location.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!location.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image  jpeg tipinnen fayl secin! ");
                return View();
            }


            location.Image = location.ImageFile.CreateImage(_env, "assets", "img", "About");
            location.CreatBy = "System";
            location.IsDeleted = false;
            location.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Locations.AddAsync(location);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Location location = await _context.Locations.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (location == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(location);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Location location = await _context.Locations.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (location == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(location);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Location location)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (location.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Location existedLocation = await _context.Locations.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (existedLocation == null) return NotFound("id tapilmadi");


            bool isExist = _context.Locations.Any(c => c.Title.ToLower() == location.Title.ToLower().Trim() && c.Adress.ToLower() == location.Adress.ToLower().Trim());
            if (isExist && !(existedLocation.Adress.ToLower() == location.Adress.ToLower().Trim() && existedLocation.Title.ToLower() == location.Title.ToLower()))
            {
                ModelState.AddModelError("Name", "Bu adla Adress var");
                return View();
            };


            if (existedLocation == null) return NotFound("id tapilmadi");

            if (location.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!location.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!location.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedLocation.Image, "assets", "img", "About");
            existedLocation.Image = location.ImageFile.CreateImage(_env, "assets", "img", "About");
            existedLocation.Title = location.Title.ToLower();
            existedLocation.Adress = location.Adress;
            existedLocation.Email = location.Email;
            existedLocation.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedLocation.IsDeleted = false;
            existedLocation.UpdateBy = "System";
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");


        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Location location = await _context.Locations
    .FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (location == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (location.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }



            location.IsDeleted = true;
            location.DeletedAt = DateTime.UtcNow.AddHours(4);
            location.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = 200 });
        }
    }
}
