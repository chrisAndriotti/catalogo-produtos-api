using Application.DTOs;

namespace Application.Interfaces;

public interface IProductService
{
    IReadOnlyList<ProductDto> Search(string? name, string? category, decimal? minPrice, decimal? maxPrice);
}
