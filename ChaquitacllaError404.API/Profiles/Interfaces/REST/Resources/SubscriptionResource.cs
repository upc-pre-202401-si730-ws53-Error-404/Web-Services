using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;

public record SubscriptionResource(int Id, string Description, decimal Price, int Range);