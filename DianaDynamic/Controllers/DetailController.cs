using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DianaDynamic.Controllers
{
    public class DetailController : Controller
    {
        AppDBC _context;
        private readonly IWebHostEnvironment _env;

        public DetailController(AppDBC context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        public IActionResult Detail (int Id)
        {
            Product product = _context.products.Include(c => c.Category)
                .Include(img => img.Images)
                .Include(pc => pc.productColors)
                .ThenInclude(c => c.Color)
                .Include(pm => pm.productMaterials)
                .ThenInclude(m => m.Material)
                .Include(ps => ps.ProductSizes)
                .ThenInclude(s => s.Size)
                .Where(p => p.Id == Id);


        }


    }
}
            Product product =  _context.products
            .Where(p => p.Id == Id)
            .Include(p => p.productColors)
            .ThenInclude(p => p.Color)
            .Include(p => p.productMaterials)
            .ThenInclude(p => p.Material)
            .Include(p => p.ProductSizes)
            .ThenInclude(p => p.Size)
            .Include(p => p.Images).ToList();