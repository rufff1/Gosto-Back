using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Service :BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Image { get; set; }
        [StringLength(150)]
        [Required]
        public string Title { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
    }
}
