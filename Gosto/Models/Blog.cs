using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Blog :BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Image { get; set; }
        [StringLength(150)]
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(50)]
        public string Author { get; set; }
        [Required]
        [StringLength(50)]
        public DateTime BlogTime { get; set; }

        [StringLength(1000)]
        public string Description1 { get; set; }
        [StringLength(1000)]
        public string Description2 { get; set; }
        [StringLength(1000)]
        public string DescQuota { get; set; }
        [StringLength(1000)]
        public string Description3 { get; set; }


        public List<BlogTag> BlogTags { get; set; }

        public BlogCategory BlogCategory { get; set; }
        public int BlogCategoryId { get; set; }

    }
}
