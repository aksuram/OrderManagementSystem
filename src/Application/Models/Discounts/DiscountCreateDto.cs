namespace OrderManagementSystem.Application.Models.Discounts
{
    public class DiscountCreateDto
    {
        public Guid ProductId { get; set; }
        public decimal Percentage { get; set; } = decimal.Zero;
        public int? QuantityThreshold { get; set; } = 0;
    }
}
