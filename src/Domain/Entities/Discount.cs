namespace OrderManagementSystem.Domain.Entities
{
    public class Discount
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public decimal Percentage { get; set; } = decimal.Zero;
        public int QuantityThreshold { get; set; } = 0;

        public Guid ProductId { get; set; }
        public Product Product { get; set; } = null!;
    }
}
