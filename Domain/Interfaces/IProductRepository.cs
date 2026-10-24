using Domain.Entities;

namespace Domain.Interfaces;

public interface IProductRepository
{
    IReadOnlyCollection<Product> GetAll();
}
