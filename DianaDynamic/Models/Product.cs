namespace DianaDynamic.Models
{
    public class Product:Entity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public List<ProductImages>? Images { get; set; }
        public List<ProductSize>? ProductSizes { get; set; }
        public List<ProductColor>? productColors { get; set; }
        public List<ProductMaterial>? productMaterials { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
