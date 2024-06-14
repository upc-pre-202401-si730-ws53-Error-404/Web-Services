namespace ChaquitacllaError404.API.Users.Domain.Model.Entities;

public class Subscription
{
    public int Id { get; private set; }
    public string  Description { get; private set; }
    public int Price { get; private set; }
    public int  UserId { get; set; } // Navigation Property
    
    public Subscription()
    {
        Price = 0;
        Description = string.Empty;
        UserId = 0;
    }
    
    public Subscription(string description, int price, int userId)
    {
        Description = description;
        Price = price;
        UserId = userId;
    }
}