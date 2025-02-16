using OrderManagementSystem.Application.Models.Products;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Common.Mappings
{
    public static class ProductMappings
    {
        public static ProductVm ToProductVm(this Product product)
        {
            return new ProductVm {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
