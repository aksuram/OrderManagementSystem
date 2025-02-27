﻿namespace OrderManagementSystem.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; } = decimal.MaxValue;

        public Discount? Discount { get; set; }

        public List<OrderProduct> OrderProducts { get; set; } = null!;
    }
}
