namespace OrderManagementSystem.Application.Models.Orders
{
    public class OrderCreateDto
    {
        public List<OrderProductCreateDto> Products { get; set; } = null!;
    }
}
