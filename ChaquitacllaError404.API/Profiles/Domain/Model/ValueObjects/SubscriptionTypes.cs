namespace ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

public enum SubscriptionTypes
{
    Test_Subscription = 1,
    Anual_Subscription = 2
}
public static class SubscriptionRange
{
    public static string ToDescription(this SubscriptionTypes range)
    {
        switch (range)
        {
            case SubscriptionTypes.Test_Subscription:
                return "Test_Subscription";
            case SubscriptionTypes.Anual_Subscription:
                return "Anual_Subscription";
            // Agrega más aquí si es necesario
            default:
                return "Unknown Subscription Range";
        }
    }
}