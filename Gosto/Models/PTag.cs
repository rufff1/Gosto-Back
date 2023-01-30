using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class PTag :BaseEntity
    {
        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        public IEnumerable<ProductTag> ProductTags { get; set; }

    }
}
