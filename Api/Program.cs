var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<Domain.Interfaces.IProductRepository, Infrastructure.Repositories.InMemoryProductRepository>();
builder.Services.AddSingleton<Application.Interfaces.IProductService, Application.Services.ProductService>();

var app = builder.Build();

app.MapControllers();

app.Run();
