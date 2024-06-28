using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class ControlRepository : BaseRepository<Control>, IControlRepository
{
    public ControlRepository(AppDbContext context) : base(context)
    {
        
    }

    public async Task<IEnumerable<Control>> FindBySowingIdAsync(int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.SowingId == sowingId)
            .ToListAsync();
    }

    public async Task<IEnumerable<Control>> FindByIdAndSowingIdAsync(int id, int sowingId)
    {
        return await Context.Set<Control>()
            .Where(c => c.Id == id && c.SowingId == sowingId)
            .ToListAsync();
    }

    public void Delete(Control control)
    {
        Context.Set<Control>().Remove(control);
    }
}