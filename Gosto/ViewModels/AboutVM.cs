using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class AboutVM
    {
        public HiGosto HiGosto { get; set; }
        public WelcomeGosto WelcomeGosto { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<Texnology> Texnologies { get; set; }
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Location> Locations { get; set; }
    }
}
