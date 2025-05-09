using ChaquitacllaError404.API.Profiles.Domain.Model.Entities;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST.Transform;

public static class SubscriptionResourceFromEntityAssembler
{
    public static SubscriptionResource ToResourceFromEntity(Subscription subscription)
    {
        return new SubscriptionResource(subscription.Id, subscription.Description, subscription.Price, subscription.Range);
    }
}