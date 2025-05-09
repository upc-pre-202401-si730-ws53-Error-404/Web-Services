using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Profiles.Domain.Model.Entities;

public class Subscription
{
    public int Id { get; init; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Range { get; set; }

    public Subscription(string description, decimal price, int range)
    {
        Description = description;
        Price = price;
        Range = range;
    }
    
    public Subscription(CreateSubscriptionCommand command)
    {
        Description = command.Description;
        Price = command.Price;
        Range = command.Range;
    }
}