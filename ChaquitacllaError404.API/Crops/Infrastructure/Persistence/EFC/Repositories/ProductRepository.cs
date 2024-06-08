using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> FindByTypeAsync(EProductType type)
    {
        return await Context.Set<Product>().Where(f => f.Type == type)
            .ToListAsync();
    }
}