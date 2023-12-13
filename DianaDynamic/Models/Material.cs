namespace DianaDynamic.Models
{
    public class Material : Entity
    {
        public string? Name { get; set; }
        public List<ProductMaterial>? productMaterials { get; set; }

    }
}
