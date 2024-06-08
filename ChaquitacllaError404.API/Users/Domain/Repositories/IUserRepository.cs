using ChaquitacllaError404.API.Shared.Domain.Repositories;
using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Users.Domain.Repositories;

public interface IUserRepository: IBaseRepository<User>
{
    Task<User?> FindByFirstNameAsync(string firstName);
    Task<User?> FindByLastNameAsync(string lastName);
    Task<IEnumerable<User>> FindByCountryAsync(string country);
    Task<IEnumerable<User>> FindByCityAsync(string city);
}