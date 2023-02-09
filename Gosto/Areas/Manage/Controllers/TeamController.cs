using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Gosto.ViewModels;
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
    public class TeamController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public TeamController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index(int pageIndex)
        {


            IQueryable<Team> teams =  _context.Teams.Where(b => b.IsDeleted == false);
            return View(PageNationList<Team>.Create(teams, pageIndex, 3));
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Team team)
        {

            if (!ModelState.IsValid)
            {

                return View(team);
            }



            if (team.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!team.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!team.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }


            team.Image = team.ImageFile.CreateImage(_env, "assets", "img", "Our-team");
            team.FullName = team.FullName;
            team.Position = team.Position;
            team.Info = team.Info;
            team.Reply = team.Reply;
            team.CreatBy = "System";
            team.IsDeleted = false;
            team.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Teams.AddAsync(team);
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

            Team team = await _context.Teams.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (team == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(team);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Team team = await _context.Teams.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (team == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            return View(team);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Team team)
        {

            if (!ModelState.IsValid)
            {

                return View();
            }

            if (id == null) return BadRequest("Id daxil edin");

            if (team.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Team existedTeam = await _context.Teams.FirstOrDefaultAsync(b => b.IsDeleted == false && b.Id == id);

            if (existedTeam == null) return NotFound("id tapilmadi");

          

           


          

            if (team.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Image daxil edin");
                return View();
            }

            if (!team.ImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("ImageFile", "Image olcusu 1mb cox olmamalidir");
                return View();
            }
            if (!team.ImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("ImageFile", "image jpeg tipinnen fayl secin! ");
                return View();
            }

            Helper.DeleteFile(_env, existedTeam.Image, "assets", "img", "Our-team");
            existedTeam.Image = team.ImageFile.CreateImage(_env, "assets", "img", "Our-team");
            existedTeam.Info = team.Info;
            existedTeam.FullName = team.FullName;
            existedTeam.Position = team.Position;
            existedTeam.Reply = team.Position;
            existedTeam.UpdateAt = DateTime.UtcNow.AddHours(4);
            existedTeam.IsDeleted = false;
            existedTeam.UpdateBy = "System";
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

            Team team = await _context.Teams.FirstOrDefaultAsync(c => c.IsDeleted == false && c.Id == id);


            if (team == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (team.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }





            team.IsDeleted = true;
            team.DeletedAt = DateTime.UtcNow.AddHours(4);
            team.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index", new { status = 200 });
        }
    }
}
