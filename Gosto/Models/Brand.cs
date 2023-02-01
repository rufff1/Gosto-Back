using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Brand : BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Image { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(1000)]
        public string BrandInfo { get; set; }

        public IEnumerable<Product> Products { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }

    }
}
