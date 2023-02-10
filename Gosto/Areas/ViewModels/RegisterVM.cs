using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.ViewModels
{
    public class RegisterVM
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Paswoord { get; set; }
        [Compare(nameof(Paswoord))]
        [DataType(DataType.Password)]
        public string ConfirmPaswoord { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string Phone { get; set; }
        public IFormFile UserImageFile { get; set; }
    }
}
