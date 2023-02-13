using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.ViewModels
{
    public class DashboardVM
    {
        public IEnumerable<AppUser> AppUsers { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<Product> SellingProduct { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public Product Product { get; set; }
    }
}
