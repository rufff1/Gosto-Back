using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.ViewModels
{
    public class RegstrVM
    {
        [Required]
        [StringLength(maximumLength: 30)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 90)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [StringLength(maximumLength: 40)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Job { get; set; }
        public string Country { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public bool TermsAndConditions { get; set; }
        public IFormFile UserImageFile { get; set; }
    }
}
