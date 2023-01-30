using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class BTag :BaseEntity
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; }

        public IEnumerable<BlogTag> BlogTags { get; set; }
    }
}
