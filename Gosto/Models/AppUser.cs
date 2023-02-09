using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class AppUser :IdentityUser
    {
        public string Name { get; set; }

        [StringLength(1000)]
        public string UserImage { get; set; }
        [NotMapped]
        public IFormFile UserImageFile { get; set; }

    }
}
