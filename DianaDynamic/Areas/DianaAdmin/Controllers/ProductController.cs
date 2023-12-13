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