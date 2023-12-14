using DianaDynamic.Areas.DianaAdmin.ViewModels.Product;
using DianaDynamic.Helper;
using DianaDynamic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace DianaDynamic.Areas.DianaAdmin.Controllers
{

    [Area("DianaAdmin")]

    public class ProductController : Controller
    {
        AppDBC _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDBC context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.products
            .Include(p => p.Images).ToListAsync();
            
            List<Product> productsList = _context.products.ToList();
            return View(products);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.colors = await _context.colors.ToListAsync();
            ViewBag.categories = await _context.categories.ToListAsync();
            ViewBag.sizes = await _context.sizes.ToListAsync();
            ViewBag.materials = await _context.Materials.ToListAsync();
            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProduct createProduct)
        {
            ViewBag.colors = await _context.colors.ToListAsync();
            ViewBag.categories = await _context.categories.ToListAsync();
            ViewBag.sizes = await _context.sizes.ToListAsync();
            ViewBag.materials = await _context.Materials.ToListAsync();
            if (createProduct is null) return NotFound();
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product product = new Product()
            {
                Name = createProduct.Name,
                Description = createProduct.Description,
                Price = createProduct.Price,
                CategoryId = createProduct.CategoryId,
                Images = new List<ProductImages>()
            };

            foreach (var item in createProduct.SizeIds)
            {
                

                ProductSize productSize = new ProductSize()
                {
                    Product = product,
                    SizeId = item,
                };

                await _context.productSizes.AddAsync(productSize);
            }
            foreach (var item in createProduct.ColorIds)
            {


                ProductColor productColor = new ProductColor()
                {
                    Product = product,
                    ColorId = item,
                };

                await _context.productColors.AddAsync(productColor);
            }
            foreach (var item in createProduct.MaterialIds)
            {


                ProductMaterial productMaterial = new ProductMaterial()
                {
                    Product = product,
                    MaterialId = item,
                };

                await _context.ProductMaterials.AddAsync(productMaterial);
            }

            if (createProduct.Photos != null)
            {
                foreach (IFormFile imgFile in createProduct.Photos)
                {
                    if (!imgFile.CheckContent("image/"))
                    {
                        TempData["Error"] += $"{imgFile.FileName} uygun tipde deyil ";
                        continue;
                    }
                    if (!imgFile.CheckLenght(2097152))
                    {
                        TempData["Error"] += $"{imgFile.FileName} file-nin olcusu coxdur";
                        continue;
                    }
                    ProductImages productImage = new ProductImages()
                    {
                        Product = product,
                        ImageUrl = imgFile.UploadFile(_env.WebRootPath, "/Upload/Product/")
                    };
                    product.Images.Add(productImage);

                }
            }
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();



            return RedirectToAction(nameof(Index));
        }


    }
}


/*
List<Product> products = await _context.products
.Include(p => p.productColors)
.ThenInclude(p => p.Color)
.Include(p => p.productMaterials)
.ThenInclude(p => p.Material)
.Include(p => p.ProductSizes)
.ThenInclude(p => p.Size)
.Include(p => p.Images).ToListAsync();*/