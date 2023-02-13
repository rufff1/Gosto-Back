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
 
        public string Job { get; set; }

        public string Country { get; set; }
  
        public string Adress { get; set; }

        public string Phone { get; set; }

        [StringLength(1000)]
        public string UserImage { get; set; }
        [NotMapped]
        public IFormFile UserImageFile { get; set; }
        public string EmailConfirmationToken { get; set; }
        public string PasswordResetToken { get; set; }
        public bool isConfirmed { get; set; }
        public string ConnectionId { get; set; }

    }
}
