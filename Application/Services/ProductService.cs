using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services;

public sealed class ProductService(IProductRepository productRepository) : IProductService
{
    public IReadOnlyList<ProductDto> Search(string? name, string? category, decimal? minPrice, decimal? maxPrice)
    {
        var products = productRepository.GetAll();

        return products
            .Where(product => string.IsNullOrWhiteSpace(name)
                || product.Name.Contains(name.Trim(), StringComparison.OrdinalIgnoreCase))
            .Where(product => string.IsNullOrWhiteSpace(category)
                || product.Category.Equals(category.Trim(), StringComparison.OrdinalIgnoreCase))
            .Where(product => minPrice is not decimal minimum || product.Price >= minimum)
            .Where(product => maxPrice is not decimal maximum || product.Price <= maximum)
            .OrderBy(product => product.Id)
            .Select(product => new ProductDto(product.Id, product.Name, product.Category, product.Price))
            .ToArray();
    }
}
