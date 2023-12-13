namespace DianaDynamic.Models
{
    public class ProductImages : Entity
    {
        public int? ProductId { get; set; }
        public Product? Product { get; set; }
        public string ImageUrl { get; set; }

    }
}
