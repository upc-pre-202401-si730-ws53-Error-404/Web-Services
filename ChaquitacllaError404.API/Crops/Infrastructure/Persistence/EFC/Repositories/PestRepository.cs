using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class PestRepository : BaseRepository<Pest>, IPestRepository
{
    public PestRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<Pest>> FindAllAsync()
    {
        return await Context.Set<Pest>().ToListAsync();
    }
    public async Task<IEnumerable<Pest>> GetPestByCropIdQuery(int cropId)
    {
        var crop = await Context.Set<Crop>()
            .Include(c => c.Pests)
            .FirstOrDefaultAsync(c => c.Id == cropId);

        return crop?.Pests;
    }
}