using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class PestRepository : BaseRepository<Pest>, IPestRepository
{
    public PestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Pest>> FindByNameAsync(string name) =>
        await Context.Set<Pest>()
            .Where(p => p.Name == name)
            .Include(p => p.Crops)
            .ToListAsync();

    public new async Task<Pest?> FindByIdAsync(int id) => await Context.Set<Pest>()
        .Include(pest => pest.Crops)
        .FirstOrDefaultAsync(pest => pest.Id == id);

    public new async Task<IEnumerable<Pest>> ListAsync() => await Context.Set<Pest>()
        .Include(pest => pest.Crops)
        .ToListAsync();

    public async Task<IEnumerable<Pest>> FindByCropIdAsync(int cropId)
    {
        return await Context.Set<Pest>()
            .Where(p => p.Crops.Any(c => c.Id == cropId))
            .Include(p => p.Crops)
            .ToListAsync();
    }
}