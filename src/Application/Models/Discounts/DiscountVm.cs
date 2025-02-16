namespace OrderManagementSystem.Application.Models.Discounts
{
    public class DiscountVm
    {
        public Guid Id { get; set; }
        public decimal Percentage { get; set; }
        public int QuantityThreshold { get; set; }
        public Guid ProductId { get; set; }
    }
}
