namespace ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

public record CreateUserResource(string FirstName, string LastName, string Email, string Password,  string City, string Country);