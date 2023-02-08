using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class ProductCategory :BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [StringLength(255)]
  
        public string Image { get; set; }

        public IEnumerable<Product> Products { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
