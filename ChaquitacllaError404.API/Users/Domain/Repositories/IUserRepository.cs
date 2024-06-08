using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using FlexPalPlatform.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Users.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByFirstNameAsync(string firstName);
    Task<User?> FindByLastNameAsync(string lastName);
}