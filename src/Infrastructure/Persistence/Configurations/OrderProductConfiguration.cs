using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Infrastructure.Persistence.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Quantity)
                .IsRequired();


            builder.Property(x => x.OrderId)
                .IsRequired();

            builder.Property(x => x.ProductId)
                .IsRequired();
        }
    }
}
