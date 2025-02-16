using Microsoft.EntityFrameworkCore;
using OrderManagementSystem.Application.Common.Interfaces;
using OrderManagementSystem.Application.Common.Mappings;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Common.Querying;
using OrderManagementSystem.Application.Models.Products;
using OrderManagementSystem.Application.Services.Interfaces;
using OrderManagementSystem.Application.Validators.Products;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductService(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Result<ProductVm>> CreateProduct(ProductCreateDto productCreateDto)
        {
            ProductCreateDtoValidator validator = new ProductCreateDtoValidator();
            var validationResult = validator.Validate(productCreateDto);

            if (!validationResult.IsValid)
            {
                return Result<ProductVm>.BadData(validationResult.Errors.Select(x =>
                    new FieldError(x.PropertyName, x.ErrorMessage)));
            }

            var product = new Product
            {
                Name = productCreateDto.Name,
                Price = productCreateDto.Price
            };

            _applicationDbContext.Products.Add(product);
            await _applicationDbContext.SaveChangesAsync();

            return Result<ProductVm>.Success(product.ToProductVm());
        }

        public async Task<Result<PaginatedList<ProductVm>>> GetProducts(ProductListDto productListDto)
        {
            ProductListDtoValidator validator = new ProductListDtoValidator();
            var validationResult = validator.Validate(productListDto);

            if (!validationResult.IsValid)
            {
                return Result<PaginatedList<ProductVm>>.BadData(validationResult.Errors.Select(x =>
                    new FieldError(x.PropertyName, x.ErrorMessage)));
            }

            var products = await _applicationDbContext.Products
                .AsNoTracking()
                .WhereIf(productListDto.Search != null && productListDto.Search != "",
                            x => x.Name.Contains(productListDto.Search!))
                .OrderBy(x => x.Id)
                .Select(x => new ProductVm { Id = x.Id, Name = x.Name, Price = x.Price })
                .PaginatedListAsync(productListDto.PageNumber, productListDto.PageSize);

            if (products.Items.Count == 0)
            {
                return Result<PaginatedList<ProductVm>>.NotFound("pageNumber", "Could not find any products");
            }

            return Result<PaginatedList<ProductVm>>.Success(products);
        }
    }
}
