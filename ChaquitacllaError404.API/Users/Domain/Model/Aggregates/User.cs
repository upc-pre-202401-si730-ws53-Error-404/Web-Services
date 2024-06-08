using ChaquitacllaError404.API.Users.Domain.Model.Commands;
using ChaquitacllaError404.API.Users.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Users.Domain.Model.Aggregates;

public partial class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string Password { get; set; }
    public int Price { get; private set; }
    public string Description { get; private set; }
    public string City { get; private set; }
    public string Country { get; private set; }
    
    public User()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
        this.Price = 0;
        this.Description = string.Empty;
        this.City = string.Empty;
        this.Country = string.Empty;
    }

    public User(CreateUserCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Email = command.Email;
        this.Password = command.Password;
        this.Price = command.Price;
        this.Description = command.Description;
        this.City = command.City;
        this.Country = command.Country;
    }
    
    public bool VerifyPassword(string password)
    {
        return BCrypt.Net.BCrypt.Verify(password, this.Password);
    }
    public static string EncryptPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
}