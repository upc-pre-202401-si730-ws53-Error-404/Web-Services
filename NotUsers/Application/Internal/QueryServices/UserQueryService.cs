using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Domain.Model.Queries;
using ChaquitacllaError404.API.Users.Domain.Repositories;
using ChaquitacllaError404.API.Users.Domain.Services;

namespace ChaquitacllaError404.API.Users.Application.Internal.QueryServices;

public class UserQueryService(IUserRepository userRepository):IUserQueryService
{
    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }

    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }
    
    public async Task<User?> Handle(GetUserByFirstNameQuery query)
    {
        return await userRepository.FindByFirstNameAsync(query.FirstName);
    }
    
    public async Task<User?> Handle(GetUserByLastNameQuery query)
    {
        return await userRepository.FindByLastNameAsync(query.LastName);
    }

    public async Task<IEnumerable<User?>> Handle(GetUserByCountryQuery query)
    {
        return await userRepository.FindByCountryAsync(query.Country);
    }

    public async Task<IEnumerable<User?>> Handle(GetUserByCityQuery query)
    {
        return await userRepository.FindByCityAsync(query.City);
    }
}