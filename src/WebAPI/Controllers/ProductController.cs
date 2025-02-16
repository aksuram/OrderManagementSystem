using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.Application.Common.Models;
using OrderManagementSystem.Application.Models.Products;
using OrderManagementSystem.Application.Services.Interfaces;

namespace OrderManagementSystem.WebAPI.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("api/product/")]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateDto productCreateDto)
        {
            Result<ProductVm> result = await _productService.CreateProduct(productCreateDto);

            return result.Type switch
            {
                ResultType.Success => Ok(result.Value),
                ResultType.BadData => BadRequest(result.GetErrors()),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }

        [HttpGet("api/product/")]
        public async Task<ActionResult> GetProducts([FromQuery] string search = "",
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            Result<PaginatedList<ProductVm>> result = await _productService.GetProducts(
                new ProductListDto
                {
                    Search = search,
                    PageNumber = pageNumber,
                    PageSize = pageSize
                });

            return result.Type switch
            {
                ResultType.Success => Ok(result.Value),
                ResultType.NotFound => NotFound(result.GetErrors()),
                ResultType.BadData => BadRequest(result.GetErrors()),
                _ => StatusCode(StatusCodes.Status500InternalServerError)
            };
        }
    }
}
