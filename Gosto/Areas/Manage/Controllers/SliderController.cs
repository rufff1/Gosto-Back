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
    
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult>  Index()
        {
            IEnumerable<Slider> sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync();

            return View(sliders);
          
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }



            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!slider.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!slider.ImageFile.CheckFileType("image/jpeg , image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }


            slider.BackImage = slider.ImageFile.CreateImage(_env, "assets", "img", "slider");
            slider.CreatBy = "System";
            slider.IsDeleted = false;
            slider.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Sliders.AddAsync(slider);
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

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);


            if (slider == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(slider);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (slider == null) return NotFound("slider tapilmadi");
            return View(slider);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Slider slider)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (slider.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Slider existedSlider = await _context.Sliders.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedSlider == null) return NotFound("id tapilmadi");

            if (slider.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!slider.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!slider.ImageFile.CheckFileType("image/jpeg,image/png"))
            {
                ModelState.AddModelError("ImageFile", "image png ve ya jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedSlider.BackImage, "assets", "img", "slider");
            existedSlider.BackImage = slider.ImageFile.CreateImage(_env, "assets", "img", "slider");
            existedSlider.Description = slider.Description;
            existedSlider.Title = slider.Title;
            slider.UpdateAt = DateTime.UtcNow.AddHours(4);
            slider.IsDeleted = false;
            slider.UpdateBy = "System";
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

            Slider slider = await _context.Sliders.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (slider == null) return NotFound("slider tapilmadi");

            if (slider.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            if (slider.BackImage.Count() > 3)
            {
                slider.IsDeleted = true;
                slider.DeletedAt = DateTime.UtcNow.AddHours(4);
                slider.DeletedBy = "System";
                await _context.SaveChangesAsync();

            }




            return View("Index");
        }

    }
}
