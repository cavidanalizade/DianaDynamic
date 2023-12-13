namespace DianaDynamic.Areas.DianaAdmin.ViewModels.Product
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }

        public List<IFormFile>? Photos { get; set; }

    }
}
