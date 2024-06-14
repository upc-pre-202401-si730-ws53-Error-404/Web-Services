using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories
{
    public interface IControlRepository
    {
        Task<Control> GetByIdAsync(long id);
        Task<List<Control>> GetAllAsync();
        Task SaveAsync(Control control);
        Task<bool> ExistsByIdAsync(long id);
        Task DeleteByIdAsync(long id);
        Task<List<Control>> GetBySowingIdAsync(int querySowingId);
        
    }
}