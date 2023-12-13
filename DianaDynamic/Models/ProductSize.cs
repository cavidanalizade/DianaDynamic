namespace DianaDynamic.Models
{
    public class ProductSize : Entity
    {
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public int? SizeId { get; set; }
        public Size? Size { get; set; }
    }
}
