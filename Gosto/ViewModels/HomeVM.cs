using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Sliders { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<Product> SellingProduct { get; set; }
        public IEnumerable<Product> TrendingProduct { get; set; }
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }

    }
}
