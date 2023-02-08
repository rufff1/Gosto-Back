using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Texnology : BaseEntity
    {
        [StringLength(150)]
   
        public string Image { get; set; }
        [StringLength(150)]
        [Required]
        public string Title1 { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description1 { get; set; }
        [StringLength(150)]
        [Required]
        public string Title2 { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description2 { get; set; }


        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
