using OrderManagementSystem.Application.Common.Interfaces;

namespace OrderManagementSystem.Application.Models.Products
{
    public class ProductListDto : IPaginatedListQuery
    {
        public required string Search { get; set; }
        public required int PageNumber { get; set; } = 1;
        public required int PageSize { get; set; } = 10;
    }
}
