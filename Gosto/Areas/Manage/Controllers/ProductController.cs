using Gosto.DAL;
using Gosto.Extensions;
using Gosto.Helpers;
using Gosto.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gosto.Areas.Manage.Controllers
{
    [Area("manage")]

    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private IWebHostEnvironment _env;
        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {

            IEnumerable<Product> products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.ProductColors)
                 .ThenInclude(pc => pc.Color)
                .Include(p => p.ProductCategory)
                .Include(p => p.ProductTags).ThenInclude(p => p.PTag)
                .Where(p => p.IsDeleted == false)
                .ToListAsync();

            return View(products);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {


            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.ProductCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.PTags.Where(t => t.IsDeleted == false).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(t => t.IsDeleted == false).ToListAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {

            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.ProductCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.PTags.Where(t => t.IsDeleted == false).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(t => t.IsDeleted == false).ToListAsync();

            if (!ModelState.IsValid)
            {

                return View(product);
            }

            if (!await _context.ProductCategories.AnyAsync(c => c.IsDeleted == false && c.Id == product.ProductCategoryId))
            {
                ModelState.AddModelError("CategoryId", "gelen categoriya yalnisdir");
                return View(product);
            }

            if (product.BrandId == null)
            {
                ModelState.AddModelError("BrandId", "gelen brand yalnisdir");
                return View(product);
            }

            if (!await _context.Brands.AnyAsync(c => c.IsDeleted == false && c.Id == product.BrandId))
            {
                ModelState.AddModelError("BrandId", "gelen brand yalnisdir");
                return View(product);
            }

            if (!(product.Price > product.DiscountedPrice && product.DiscountedPrice > 0))
            {

                ModelState.AddModelError("DiscountedPrice", "endirimi duzgun qeyd edin");
                return View(product);
            }

            if (product.Price < 0)
            {

                ModelState.AddModelError("Price", "Qiymeti duzgun qeyd edin");
                return View(product);
            }


            List<ProductTag> productTags = new List<ProductTag>();

            foreach (int tagId in product.TagIds)
            {
                if (product.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagId", "bir tagdan yalniz bir defe secilmelidir");
                    return View(product);

                }

                if (!await _context.PTags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "secilen tag yalnisdir");
                    return View(product);
                }

                ProductTag productTag = new ProductTag
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    PTagId = tagId

                };


                productTags.Add(productTag);
            }

            List<ProductColor> productColors = new List<ProductColor>();

            foreach (int colorId in product.ColorIds)
            {
                if (product.ColorIds.Where(t => t == colorId).Count() > 1)
                {
                    ModelState.AddModelError("ColorId", "bir rengden yalniz bir defe secilmelidir");
                    return View(product);

                }

                if (!await _context.Colors.AnyAsync(t => t.IsDeleted == false && t.Id == colorId))
                {
                    ModelState.AddModelError("ColorIds", "secilen tag yalnisdir");
                    return View(product);
                }

                ProductColor productColor = new ProductColor
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    ColorId = colorId

                };


                productColors.Add(productColor);
            }


          
                List<ProductImage> productImages = new List<ProductImage>();

            if (product.ProductImagesFiles != null)
            {

                foreach (IFormFile formFile in product.ProductImagesFiles)
                {
                    if (formFile != null)
                    {
                        ProductImage productImage = new ProductImage
                        {
                            Name = formFile.CreateImage(_env, "assets", "img", "Product"),
                            CreatAt = DateTime.UtcNow.AddHours(4)
                        };
                        productImages.Add(productImage);
                    }
                }

                product.ProductImages = productImages;
            }
            else
            {
                ModelState.AddModelError("ProductImagesFile", "Sekil olmalidi");
                return View(product);
            }


            if (product.ProductImagesFiles.Count() > 4)
            {
                ModelState.AddModelError("ProductImagesFile", "4 sekilden artiq yuklemek olmaz");
                return View(product);
            }


            if (product.MainImageFile == null)
            {
                ModelState.AddModelError("MainImageFile", "Fayl mecburidi");
                return View(product);
            }

            if (!product.MainImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("MainImageFile", "image jpg tipinnen fayl secin! ");
                return View();
            }

            if (!product.MainImageFile.CheckFileSize(5000))
            {
                ModelState.AddModelError("MainImageFile", "Faylin olcusu maksimum 5 mb olmalidir");
                return View(product);
            }

            product.MainImage = product.MainImageFile.CreateImage(_env, "assets", "img", "Product");


            if (product.HoverImageFile == null)
            {
                ModelState.AddModelError("HoverImageFile", "Fayl mecburidi");
                return View(product);
            }

            if (!product.HoverImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("HoverImageFile", "Faylin tipi image/jpeg ve ya png olmalidir");
                return View(product);
            }

            if (!product.HoverImageFile.CheckFileSize(5000))
            {
                ModelState.AddModelError("HoverImageFile", "Faylin olcusu maksimum 5 mb olmalidir");
                return View(product);
            }



            product.HoverImage = product.HoverImageFile.CreateImage(_env, "assets", "img", "Product");
        
            product.ProductTags = productTags;
            product.ProductColors = productColors;
            product.CreatBy = "System";
            product.IsDeleted = false;
            product.CreatAt = DateTime.UtcNow.AddHours(4);
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();




            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Update(int? id)
        {

            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.ProductCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.PTags.Where(t => t.IsDeleted == false).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(t => t.IsDeleted == false).ToListAsync();

            Product product = await _context.Products
            .Include(c => c.ProductCategory)
            .Include(b => b.Brand)
            .Include(t => t.ProductTags)
            .ThenInclude(tp => tp.PTag)
              .Include(t => t.ProductColors)
            .ThenInclude(tp => tp.Color)
            .Include(pi => pi.ProductImages)
            .FirstOrDefaultAsync(p => p.Id == id);



            if (id == null)
            {
                return BadRequest("Id null ola bilmez");

            }



            if (product == null)
            {
                return NotFound("bele mehsul tapilmadi");
            }


            product.TagIds = await _context.ProductTags.Where(pt => pt.ProductId == id).Select(x => x.PTagId).ToListAsync();
            product.ColorIds = await _context.ProductColors.Where(pt => pt.ProductId == id).Select(x => x.ColorId).ToListAsync();


            return View(product);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product)
        {

            ViewBag.Brands = await _context.Brands.Where(b => b.IsDeleted == false).ToListAsync();
            ViewBag.Categories = await _context.ProductCategories.Where(c => c.IsDeleted == false).ToListAsync();
            ViewBag.Colors = await _context.Colors.Where(t => t.IsDeleted == false).ToListAsync();
            ViewBag.Tags = await _context.PTags.Where(t => t.IsDeleted == false).ToListAsync();


            if (!ModelState.IsValid)
            {

                return View(product);
            }

            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }

            if (product.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }

            Product existedProduct = await _context.Products
                       .Include(c => c.ProductCategory)
            .Include(b => b.Brand)
            .Include(t => t.ProductTags)
            .ThenInclude(tp => tp.PTag)
              .Include(t => t.ProductColors)
            .ThenInclude(tp => tp.Color)
            .Include(pi => pi.ProductImages)
                .Include(p => p.ProductTags).FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);

            if (existedProduct == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }

            _context.ProductTags.RemoveRange(existedProduct.ProductTags);

            //bos list tuturug secilen taglari elave etmeye asagida elave edirik
            List<ProductTag> productTags = new List<ProductTag>();

            foreach (int tagId in product.TagIds)
            {
                if (product.TagIds.Where(t => t == tagId).Count() > 1)
                {
                    ModelState.AddModelError("TagId", "bir tagdan yalniz bir defe secilmelidir");
                    return View(product);

                }

                if (!await _context.PTags.AnyAsync(t => t.IsDeleted == false && t.Id == tagId))
                {
                    ModelState.AddModelError("TagIds", "secilen tag yalnisdir");
                    return View(product);
                }

                ProductTag productTag = new ProductTag
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    PTagId = tagId

                };

                //taglari bos liste add etdik
                productTags.Add(productTag);
            }


            List<ProductColor> productColors = new List<ProductColor>();

            foreach (int colorId in product.ColorIds)
            {
                if (product.ColorIds.Where(t => t == colorId).Count() > 1)
                {
                    ModelState.AddModelError("ColorId", "bir rengden yalniz bir defe secilmelidir");
                    return View(product);

                }

                if (!await _context.Colors.AnyAsync(t => t.IsDeleted == false && t.Id == colorId))
                {
                    ModelState.AddModelError("ColorIds", "secilen tag yalnisdir");
                    return View(product);
                }

                ProductColor productColor = new ProductColor
                {
                    CreatAt = DateTime.UtcNow.AddHours(+4),
                    CreatBy = "System",
                    IsDeleted = false,
                    ColorId = colorId

                };


                productColors.Add(productColor);
            }

            if (product.MainImageFile == null)
            {
                ModelState.AddModelError("MainImageFile", "Fayl mecburidi");
                return View(product);
            }

            if (!product.MainImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("MainImageFile", "image jpg tipinnen fayl secin! ");
                return View();
            }

            if (!product.MainImageFile.CheckFileSize(5000))
            {
                ModelState.AddModelError("MainImageFile", "Faylin olcusu maksimum 5 mb olmalidir");
                return View(product);
            }

            Helper.DeleteFile(_env, existedProduct.MainImage, "assets", "img", "Product");
            existedProduct.MainImage = product.MainImageFile.CreateImage(_env, "assets", "img", "Product");


            if (product.HoverImageFile == null)
            {
                ModelState.AddModelError("HoverImageFile", "Fayl mecburidi");
                return View(product);
            }

            if (!product.HoverImageFile.CheckFileType("image/jpeg"))
            {
                ModelState.AddModelError("HoverImageFile", "Faylin tipi image/jpeg ve ya png olmalidir");
                return View(product);
            }

            if (!product.HoverImageFile.CheckFileSize(1000))
            {
                ModelState.AddModelError("HoverImageFile", "Faylin olcusu maksimum 1 mb olmalidir");
                return View(product);
            }


            Helper.DeleteFile(_env, existedProduct.HoverImage, "assets", "img", "Product");
            existedProduct.HoverImage = product.HoverImageFile.CreateImage(_env, "assets", "img", "Product");
            existedProduct.Legs = product.Legs;
            existedProduct.Length = product.Length;
            existedProduct.Count = product.Count;
            existedProduct.Barcode = product.Barcode;
            existedProduct.Depth = product.Depth;
            existedProduct.Description = product.Description;
            existedProduct.Sku = product.Sku;
            existedProduct.Title = product.Title;
            existedProduct.DiscountedPrice = product.DiscountedPrice;
            existedProduct.Vendor = product.Vendor;
            existedProduct.Weight = product.Weight;
            existedProduct.SeatHeight = product.SeatHeight;
            existedProduct.Price = product.Price;
            existedProduct.Material = product.Material;
            existedProduct.ProductTags = productTags;
            existedProduct.ProductColors = productColors;
            existedProduct.IsSellingProduct = product.IsSellingProduct;
            existedProduct.IsTrendingProduct = product.IsTrendingProduct;

            existedProduct.ProductCategoryId = product.ProductCategoryId;
            existedProduct.BrandId = product.BrandId;

            product.UpdateAt = DateTime.UtcNow.AddHours(4);
            product.UpdateBy = "System";
            product.IsDeleted = false;
            await _context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteImage(int? id)
        {
            if (id == null) return BadRequest();

            Product product = await _context.Products.Include(pi => pi.ProductImages).FirstOrDefaultAsync(p => p.ProductImages.Any(pi => pi.Id == id && !pi.IsDeleted));

            if (product == null) return BadRequest();

            ProductImage proimg = product.ProductImages.FirstOrDefault(p => p.Id == id);

            Helper.DeleteFile(_env, proimg.Name, "assets", "img", "Product");

            product.ProductImages.FirstOrDefault(p => p.Id == id).IsDeleted = true;
            product.ProductImages.FirstOrDefault(p => p.Id == id).DeletedAt = DateTime.UtcNow.AddHours(4);

            await _context.SaveChangesAsync();

            return PartialView("_ProductDeleteImages", product.ProductImages.Where(p => !p.IsDeleted));
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }


            Product product = await _context.Products

            .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (product == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");

            }



            if (product.Id != id)
            {
                return BadRequest("Id bos ola bilmez");
            }


            product.IsDeleted = true;
            product.DeletedAt = DateTime.UtcNow.AddHours(4);
            product.DeletedBy = "System";

            await _context.SaveChangesAsync();

            return RedirectToAction("index");

        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return BadRequest("Id bos ola bilmez");
            }
            Product products = await _context.Products
    .Include(p => p.Brand)
    .Include(p => p.ProductColors)
     .ThenInclude(pc => pc.Color)
    .Include(p => p.ProductCategory)
    .Include(p => p.ProductTags).ThenInclude(p => p.PTag)
    .FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);


            if (products == null)
            {
                return NotFound("Daxil edilen Id yalnisdir");
            }


            return View(products);
        }
    }
}
