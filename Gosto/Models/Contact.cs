using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Contact :BaseEntity
    {
        [StringLength(maximumLength: 350)]
        [Required]

        public string Message { get; set; }
        [Required]
        [StringLength(maximumLength: 60)]
        public string Subject { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
