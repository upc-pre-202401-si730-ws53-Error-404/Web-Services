namespace ChaquitacllaError404.API.Users.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password,string City, string Country);