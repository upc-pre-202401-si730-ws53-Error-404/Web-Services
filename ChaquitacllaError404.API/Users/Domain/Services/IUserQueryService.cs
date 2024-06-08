using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Domain.Model.Commands;
using ChaquitacllaError404.API.Users.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Users.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByFirstNameQuery query);
    Task<User?> Handle(GetUserByLastNameQuery query);
}