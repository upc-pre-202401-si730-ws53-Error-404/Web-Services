using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class CareRepository: BaseRepository<Care>, ICareRepository
{
    public CareRepository(AppDbContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<Care>> GetCaresByCropIdQuery(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Cares)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Cares;
    }
}