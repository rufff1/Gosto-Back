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
    public class OurTeamController : Controller
    {

        private readonly AppDbContext _context;

        public OurTeamController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult>  Index()
        {
            OurTeamVM ourTeamVM = new OurTeamVM
            {
                OurTeam = await _context.OurTeams.FirstOrDefaultAsync(o => o.IsDeleted == false),
                CreateTrend = await _context.CreateTrends.FirstOrDefaultAsync(h => h.IsDeleted == false),
                Teams = await _context.Teams.Where(s => s.IsDeleted == false).Take(6).ToListAsync(),
                OurTeamBackImages = await _context.OurTeamBackImages.Where(s => s.IsDeleted == false).Take(3).ToListAsync(),


            };

            return View(ourTeamVM);
        }
    }
}
