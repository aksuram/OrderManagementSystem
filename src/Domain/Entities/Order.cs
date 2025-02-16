namespace OrderManagementSystem.Domain.Entities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public List<OrderProduct> OrderProducts { get; set; } = null!;
    }
}
