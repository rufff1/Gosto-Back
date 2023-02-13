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
    public class ServiceController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public ServiceController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {
            IQueryable<Service> services =  _context.Services.Where(s => s.IsDeleted == false);

            return View(PageNationList<Service>.Create(services, pageIndex, 3));

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }



            if (service.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!service.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!service.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }


            service.Image = service.ImageFile.CreateImage(_env, "assets", "img", "About");
            service.Description = service.Description;
            service.Title = service.Title;
            service.CreatBy = "System";
            service.IsDeleted = false;
            service.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Services.AddAsync(service);
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

            Service service = await _context.Services.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);


            if (service == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(service);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            Service services = await _context.Services.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (services == null) return NotFound("slider tapilmadi");
            return View(services);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Service service)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (service.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Service existedService = await _context.Services.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedService == null) return NotFound("id tapilmadi");

            if (service.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!service.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!service.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedService.Image, "assets", "img", "About");
            existedService.Image = service.ImageFile.CreateImage(_env, "assets", "img", "About");
            existedService.Description = service.Description;
            existedService.Title = service.Title;
            existedService.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedService.IsDeleted = false;
            existedService.UpdateBy = "System";
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

            Service service = await _context.Services.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (service == null) return NotFound("service tapilmadi");

            if (service.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            if (service.Title.Count() > 3)
            {
                service.IsDeleted = true;
                service.DeletedAt = DateTime.UtcNow.AddHours(4);
                service.DeletedBy = "System";
                await _context.SaveChangesAsync();

            }




            return View("Index");
        }
    }
}
