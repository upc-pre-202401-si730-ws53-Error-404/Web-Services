namespace ChaquitacllaError404.API.Users.Domain.Model.ValueObjects;

public record Subscriptions(int Price, string Description)
{
    public Subscriptions() : this(0, string.Empty)
    {
    }
}