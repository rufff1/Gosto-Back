using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Location : BaseEntity
    {
        [StringLength(150)]
        [Required]
        public string Image { get; set; }
        [StringLength(150)]
        [Required]
        public string Title { get; set; }
        [Required]
        [StringLength(100)]
        public string Adress { get; set; }
        [StringLength(90)]
        [Required]
        public string Phone { get; set; }
        [DataType(DataType.EmailAddress)]
        [StringLength(90)]
        [Required]
        public string Email { get; set; }
    }

}
