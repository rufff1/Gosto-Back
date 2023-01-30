using Gosto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class BlogVM
    {
        public Blog Blog { get; set; }
        public IEnumerable<Blog> Blogs { get; set; }
        public IEnumerable<BTag> BTags { get; set; }
        public IEnumerable<BlogTag> BlogTags { get; set; }
        public IEnumerable<BlogCategory> BlogCategories { get; set; }

    }
}
