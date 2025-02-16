using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Infrastructure.Persistence.Configurations
{
    public class DiscountConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.Property(x => x.Id)
                .IsRequired();

            builder.Property(x => x.Percentage)
                .IsRequired();

            builder.Property(x => x.QuantityThreshold)
                .IsRequired();


            builder.Property(x => x.ProductId)
                .IsRequired();
        }
    }
}
