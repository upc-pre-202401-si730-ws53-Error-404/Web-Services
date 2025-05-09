using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}