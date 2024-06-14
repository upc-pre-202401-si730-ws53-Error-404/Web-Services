using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories
{
    public class ControlRepository : BaseRepository<Control>, IControlRepository
    {
        public ControlRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Control> GetByIdAsync(long id)
        {
            return await Context.Set<Control>().FindAsync(id);
        }

        public async Task<List<Control>> GetAllAsync()
        {
            return await Context.Set<Control>().ToListAsync();
        }

        public async Task SaveAsync(Control control)
        {
            await Context.Set<Control>().AddAsync(control);
            await Context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByIdAsync(long id)
        {
            return await Context.Set<Control>().AnyAsync(c => c.Id == id);
        }

        public async Task DeleteByIdAsync(long id)
        {
            var control = await Context.Set<Control>().FindAsync(id);
            if (control != null)
            {
                Context.Set<Control>().Remove(control);
                await Context.SaveChangesAsync();
            }
        }

        public async Task<List<Control>> GetBySowingIdAsync(int sowingId)
        {
            return await Context.Set<Control>().Where(c => c.SowingId == sowingId).ToListAsync();
        }
    }
}