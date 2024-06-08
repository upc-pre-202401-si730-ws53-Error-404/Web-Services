using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class DiseaseRepository  : BaseRepository<Disease>, IDiseaseRepository
{
    public DiseaseRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Disease>> FindByCropIdAsync(int cropId)
    {
        return await Context.Set<Disease>()
            .Where(d => d.Crops.Any(c => c.Id == cropId))
            .Include(d => d.Crops)
            .ToListAsync();
    }
}