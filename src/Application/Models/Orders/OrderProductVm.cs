namespace OrderManagementSystem.Application.Models.Orders
{
    public class OrderProductVm
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; set; }
    }
}
