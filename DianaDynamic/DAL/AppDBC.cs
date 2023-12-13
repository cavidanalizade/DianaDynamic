using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DianaDynamic.DAL
{
    public class AppDBC : IdentityDbContext
    {
        public AppDBC(DbContextOptions<AppDBC> options) : base(options)
        {
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Color> colors { get; set; }
        public DbSet<Size> sizes { get; set; }
        public DbSet<ProductColor> productColors { get; set; }
        public DbSet<ProductSize> productSizes { get; set; }
        public DbSet<ProductImages> productImages { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }


    }
}
