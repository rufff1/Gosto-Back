using Gosto.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ComponentViewModels.Header
{
    public class HeaderVM
    {
        public Dictionary<string, string> Settings { get; set; }

        public IEnumerable<BasketVM> BasketVMs { get; set; }
    }
}
