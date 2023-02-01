using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class ShopVM
    {
        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
        public IEnumerable<Color> Colors { get; set; }
        public IEnumerable<ProductColor> ProductColors { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<PTag> PTags { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
        public IEnumerable<Product> SellingProduct { get; set; }
        public IEnumerable<Product> TrendingProduct { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public Product Product { get; set; }



    }
}
