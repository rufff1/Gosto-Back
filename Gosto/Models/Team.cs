using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Team :BaseEntity
    {
        [StringLength(150)]
 
        public string Image { get; set; }
        [StringLength(50)]
        [Required]
        public string FullName { get; set; }
        [StringLength(50)]
        [Required]
        public string Position { get; set; }
        [StringLength(400)]
        [Required]
        public string Info { get; set; }
        [StringLength(1000)]
        [Required]
        public string Reply { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}
