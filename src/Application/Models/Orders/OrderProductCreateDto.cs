namespace OrderManagementSystem.Application.Models.Orders
{
    public class OrderProductCreateDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
