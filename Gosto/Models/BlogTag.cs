using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class BlogTag :BaseEntity
    {
        public Blog Blog { get; set; }
        public int BlogId { get; set; }

        public BTag BTag { get; set; }
        public int BTagId { get; set; }
    }
}
