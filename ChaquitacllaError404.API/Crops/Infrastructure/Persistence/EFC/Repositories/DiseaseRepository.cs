using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
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
    
    public async Task<IEnumerable<Disease>> FindAllAsync()
    {
        return await Context.Set<Disease>().ToListAsync();
    }
    
    public async Task<IEnumerable<Disease>> GetDiseasesByCropId(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Diseases)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Diseases;
    }
}