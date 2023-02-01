using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Slider :BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string BackImage { get; set; }
        [StringLength(150)]
        [Required]
        public string Title { get; set; }
        [StringLength(1000)]
        public string Description { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
