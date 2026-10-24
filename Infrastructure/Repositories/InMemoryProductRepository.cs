using Domain.Entities;
using Domain.Interfaces;

namespace Infrastructure.Repositories;

public sealed class InMemoryProductRepository : IProductRepository
{
    private static readonly IReadOnlyCollection<Product> Products = Array.AsReadOnly(
    new[]
    {
        new Product(1, "Notebook", "Eletronicos", 3499.90m),
        new Product(2, "Teclado", "Acessorios", 249.90m),
        new Product(3, "Monitor", "Eletronicos", 1299.00m),
        new Product(4, "Mouse", "Acessorios", 119.90m)
    });

    public IReadOnlyCollection<Product> GetAll() => Products;
}
