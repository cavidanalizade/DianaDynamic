namespace DianaDynamic.Models
{
    public class ProductColor : Entity
    {
        public int? ProductId { get; set; }
        public Product? Product { get; set; }

        public int? ColorId { get; set; }
        public Color? Color { get; set; }

    }
}
