using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Products;

namespace OrderManagementSystem.Application.Services.Interfaces
{
    public interface IProductService
    {
        Task<Result<ProductVm>> CreateProduct(ProductCreateDto productCreateDto);
        Task<Result<PaginatedList<ProductVm>>> GetProducts(ProductListDto productListDto);
    }
}
