using Gosto.DAL;
using Gosto.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class WelcomeGostoController : Controller
    {
        private readonly AppDbContext _context;

        public WelcomeGostoController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
           WelcomeGosto welcomeGosto = await _context.WelcomeGostos.FirstOrDefaultAsync(c => c.IsDeleted == false);

            return View(welcomeGosto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            WelcomeGosto welcomeGosto = await _context.WelcomeGostos.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);


            if (welcomeGosto == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }
            return View(welcomeGosto);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, WelcomeGosto welcomeGosto)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            WelcomeGosto existedWelcomeGosto = await _context.WelcomeGostos.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (existedWelcomeGosto == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            if (existedWelcomeGosto.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            existedWelcomeGosto.Title = welcomeGosto.Title;
            existedWelcomeGosto.Description = welcomeGosto.Description;
            existedWelcomeGosto.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedWelcomeGosto.UpdateBy = "System";
            existedWelcomeGosto.IsDeleted = false;

            await _context.SaveChangesAsync();


            return RedirectToAction("Index");



        }

    }
}
