using Gosto.DAL;
using Gosto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult>  Index()
        {
            Location location = await _context.Locations.FirstOrDefaultAsync(w => w.IsDeleted == false);
            return View(location);
        }
    }
}
