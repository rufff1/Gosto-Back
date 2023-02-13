using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels.Account
{
    public class ProfleVM
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }


        public string Job { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        [StringLength(1000)]
        public string UserImage { get; set; }
        [DataType(DataType.Password)]
        public string CurrentPaswoord { get; set; }

        [DataType(DataType.Password)]
        public string NewPaswoord { get; set; }

        [Compare(nameof(NewPaswoord))]
        [DataType(DataType.Password)]
        public string ConfirmPaswoord { get; set; }
        public IFormFile UserImageFile { get; set; }
    }
}
