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
    public Subscriptions Subscription { get; private set; }
    
    public User()
    {
        this.FirstName = string.Empty;
        this.LastName = string.Empty;
        this.Email = string.Empty;
        this.Password = string.Empty;
        this.Subscription = new Subscriptions();
    }

    public User(CreateUserCommand command)
    {
        this.FirstName = command.FirstName;
        this.LastName = command.LastName;
        this.Email = command.Email;
        this.Password = command.Password;
        this.Subscription = new Subscriptions(command.Price, command.Description);
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