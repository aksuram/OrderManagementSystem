using MockQueryable.NSubstitute;
using NSubstitute;
using OrderManagementSystem.Application.Common.Interfaces;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Products;
using OrderManagementSystem.Application.Services;
using OrderManagementSystem.Application.Services.Interfaces;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.Application.UnitTests.Services
{
    public class ProductServiceTests
    {
        private readonly IProductService _productService;
        private readonly IApplicationDbContext _applicationDbContext;

        public ProductServiceTests()
        {
            _applicationDbContext = Substitute.For<IApplicationDbContext>();
            _productService = new ProductService(_applicationDbContext);
        }

        [Fact]
        public async Task CreateProduct_InvalidProduct_ReturnsBadDataResultType()
        {
            var products = new List<Product>();
            var mockProductDbSet = products.AsQueryable().BuildMockDbSet();
            _applicationDbContext.Products.Returns(mockProductDbSet);

            var productCreateDto = new ProductCreateDto
            {
                Name = "",
                Price = 0.0m
            };

            var result = await _productService.CreateProduct(productCreateDto);

            Assert.Equivalent(result.Type, ResultType.BadData);
        }

        [Fact]
        public async Task CreateProduct_ValidProduct_ReturnsSuccessResultType()
        {
            var products = new List<Product>();
            var mockProductDbSet = products.AsQueryable().BuildMockDbSet();
            _applicationDbContext.Products.Returns(mockProductDbSet);

            var productCreateDto = new ProductCreateDto
            {
                Name = "Test",
                Price = 0.0m
            };

            var result = await _productService.CreateProduct(productCreateDto);

            Assert.Equivalent(result.Type, ResultType.Success);
        }
    }
}
