namespace OrderManagementSystem.Application.Models.Products
{
    public class ProductCreateDto
    {
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
