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
    public class TexnologyController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public TexnologyController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {


            IQueryable<Texnology> texnologies = _context.Texnologies.Where(s => s.IsDeleted == false);

            return View(PageNationList<Texnology>.Create(texnologies, pageIndex, 3));

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Texnology texnology)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }



            if (texnology.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!texnology.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!texnology.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }


            texnology.Image = texnology.ImageFile.CreateImage(_env, "assets", "img", "About");
            texnology.Description1 = texnology.Description1;
            texnology.Description2 = texnology.Description2;
            texnology.Title1 = texnology.Title1;
            texnology.Title2 = texnology.Title2;
            texnology.CreatBy = "System";
            texnology.IsDeleted = false;
            texnology.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Texnologies.AddAsync(texnology);
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

            Texnology texnology = await _context.Texnologies.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);


            if (texnology == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(texnology);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {


            if (id == null) return BadRequest("Duzgun Id daxil edin");

            Texnology texnology = await _context.Texnologies.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (texnology == null) return NotFound("texnology tapilmadi");
            return View(texnology);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Texnology texnology)
        {


            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (texnology.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Texnology existedTexnology = await _context.Texnologies.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (existedTexnology == null) return NotFound("id tapilmadi");

            if (texnology.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!texnology.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!texnology.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedTexnology.Image, "assets", "img", "About");
            existedTexnology.Image = texnology.ImageFile.CreateImage(_env, "assets", "img", "About");
            existedTexnology.Description1 = texnology.Description1;
            existedTexnology.Description2 = texnology.Description2;
            existedTexnology.Title1 = texnology.Title1;
            existedTexnology.Title2 = texnology.Title2;
            existedTexnology.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedTexnology.IsDeleted = false;
            existedTexnology.UpdateBy = "System";
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

            Texnology texnology = await _context.Texnologies.FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (texnology == null) return NotFound("service tapilmadi");

            if (texnology.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            if (texnology.Image.Count() > 2)
            {
                texnology.IsDeleted = true;
                texnology.DeletedAt = DateTime.UtcNow.AddHours(4);
                texnology.DeletedBy = "System";
                await _context.SaveChangesAsync();

            }




            return View("Index");
        }
    }
}
