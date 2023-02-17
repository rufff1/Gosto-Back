using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Comment :BaseEntity
    {
        public DateTime CreatedTime { get; set; }
        [Required]
        [StringLength(maximumLength: 350)]
        public string Message { get; set; }
  
        [StringLength(maximumLength: 60)]
        public string Subject { get; set; }

        public bool IsAccepted { get; set; }

        public IEnumerable<Comment> Comments { get; set; }
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }



        public int? BlogId { get; set; }

        public Blog Blog { get; set; }


     
    }
}
