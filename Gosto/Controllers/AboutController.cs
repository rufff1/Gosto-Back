using Gosto.DAL;
using Gosto.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Controllers
{
    public class AboutController : Controller
    {
        private readonly AppDbContext _context;

        public AboutController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {

            AboutVM aboutVM = new AboutVM
            {
                HiGosto = await _context.HiGostos.FirstOrDefaultAsync(h => h.IsDeleted == false),
                WelcomeGosto = await _context.WelcomeGostos.FirstOrDefaultAsync(w => w.IsDeleted == false),
                Services = await _context.Services.Where(s => s.IsDeleted == false).Take(3).ToListAsync(),
                Texnologies = await _context.Texnologies.Where(t => t.IsDeleted == false).Take(2).ToListAsync(),
                Brands = await _context.Brands.Where(n => n.IsDeleted == false).Take(9).ToListAsync(),
                Locations = await _context.Locations.Where(n => n.IsDeleted == false).Take(3).ToListAsync()

            };
            return View(aboutVM);
        }
    }
}
