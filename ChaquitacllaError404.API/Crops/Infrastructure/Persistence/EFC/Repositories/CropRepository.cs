using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class CropRepository : BaseRepository<Crop>, ICropRepository
{
    public CropRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task UpdateAsync(Crop crop)
    {
        Context.Set<Crop>().Update(crop);
        await Context.SaveChangesAsync();
    }

    public Task<List<Crop>> FindAllAsync()
    {
        return Context.Set<Crop>().ToListAsync();
    }
}