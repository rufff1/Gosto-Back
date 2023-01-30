using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class OurTeamVM
    {
        public OurTeam OurTeam { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<OurTeamBackImage> OurTeamBackImages { get; set; }
        public CreateTrend CreateTrend { get; set; }

    }
}
