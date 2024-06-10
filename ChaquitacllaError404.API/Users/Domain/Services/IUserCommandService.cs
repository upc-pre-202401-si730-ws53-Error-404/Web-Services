using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Users.Domain.Services;

public interface IUserCommandService
{
    Task<User?> Handle(CreateUserCommand command);
    Task<User?> Handle(CreateUserCommand command, string firstName, string lastName, string email,string city, string country);
}