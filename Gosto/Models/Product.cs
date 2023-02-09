using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Models
{
    public class Product :BaseEntity
    {
        [StringLength(255)]
        [Required]
        public string Title { get; set; }
        [DataType("money")]
        [Required]
        public double Price { get; set; }
        [Display(Name = "Endirim Qiymeti")]
        public double DiscountedPrice { get; set; }
        [StringLength(1000)]
        [Required]
        public string Description { get; set; }
        [Required]
        public int Count { get; set; }
        [StringLength(255)]
        [Required]
        public string Vendor { get; set; }
        public string Sku { get; set; }
        [StringLength(4)]
        public string Barcode { get; set; }



        public string Material { get; set; }
        public string Legs { get; set; }
        public string Weight { get; set; }
        public string Length { get; set; }
        public string SeatHeight { get; set; }
        public string Depth { get; set; }


        [StringLength(255)]
   
        public string MainImage { get; set; }
        [StringLength(255)]
        public string HoverImage { get; set; }
        public bool IsSellingProduct { get; set; }
        public bool IsTrendingProduct { get; set; }
     
        public ProductCategory ProductCategory { get; set; }
      
        public int ProductCategoryId { get; set; }

        public Nullable<int> BrandId { get; set; }
        public Brand Brand { get; set; }



        public IEnumerable<ProductColor> ProductColors { get; set; }
        public IEnumerable<ProductTag> ProductTags { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }


        [NotMapped]
        public IFormFile MainImageFile { get; set; }
        [NotMapped]
        public IFormFile HoverImageFile { get; set; }
        [NotMapped]
        public IEnumerable<IFormFile> ProductImagesFiles { get; set; }
        [NotMapped]
        [MaxLength(3)]
        public IEnumerable<int> TagIds { get; set; }
        [NotMapped]
        public IEnumerable<int> ColorIds { get; set; }

    }
}
