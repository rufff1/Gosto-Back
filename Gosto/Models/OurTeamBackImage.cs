using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class OurTeamBackImage :BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Image { get; set; }
    }
}
