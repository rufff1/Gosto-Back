using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class ProductColor :BaseEntity
    {
        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Color Color { get; set; }
        public int ColorId { get; set; }
    }
}
