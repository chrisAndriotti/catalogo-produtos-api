using Application.Services;
using Infrastructure.Repositories;
using Xunit;

namespace Api.Tests;

public sealed class ProductServiceTests
{
    private readonly ProductService _service = new(new InMemoryProductRepository());

    [Fact]
    public void SearchWithoutFiltersReturnsAllProductsInStableOrder()
    {
        var products = _service.Search(null, null, null, null);

        Assert.Equal(new[] { 1, 2, 3, 4 }, products.Select(product => product.Id));
    }

    [Fact]
    public void SearchFiltersByNameWithoutCaseSensitivity()
    {
        var products = _service.Search("MON", null, null, null);

        Assert.Single(products);
        Assert.Equal("Monitor", products[0].Name);
    }

    [Fact]
    public void SearchFiltersByCategoryAndPriceRange()
    {
        var products = _service.Search(null, "eletronicos", 1000, 2000);

        Assert.Single(products);
        Assert.Equal("Monitor", products[0].Name);
    }

    [Fact]
    public void SearchReturnsEmptyCollectionWhenThereAreNoMatches()
    {
        var products = _service.Search("inexistente", null, null, null);

        Assert.Empty(products);
    }
}
