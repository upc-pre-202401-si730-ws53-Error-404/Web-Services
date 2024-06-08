using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Users.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    public async Task<User?> FindByFirstNameAsync(string firstName)
    {
        return await context.Set<User>().FirstOrDefaultAsync(user => user.FirstName == firstName);
    }

    public async Task<User?> FindByLastNameAsync(string lastName)
    {
        return await context.Set<User>().FirstOrDefaultAsync(user => user.FirstName == lastName);
    }
}