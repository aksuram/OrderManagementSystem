namespace OrderManagementSystem.Application.Models.Orders
{
    public class OrderVm
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<OrderProductVm> Products { get; set; } = null!;
    }
}
