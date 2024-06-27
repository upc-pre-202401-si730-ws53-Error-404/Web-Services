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
            .Where(d => d.CropsDiseases.Any(c => c.CropId == cropId))
            .Include(d => d.CropsDiseases)
            .ToListAsync();
    }

    public async Task<IEnumerable<Disease>> FindAllAsync()
    {
        return await Context.Set<Disease>()
            .Include(d => d.CropsDiseases)
            .ToListAsync();
    }
}