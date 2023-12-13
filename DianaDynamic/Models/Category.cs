using DianaDynamic.Models.Base;

namespace DianaDynamic.Models
{
    public class Category:Entity
    {
        public string? Name { get; set; }
        public List<Product>? Products { get; set; }

    }
}
