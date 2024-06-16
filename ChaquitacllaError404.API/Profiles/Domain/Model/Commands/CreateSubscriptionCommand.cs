using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Profiles.Domain.Model.Commands;

public record CreateSubscriptionCommand(string Description, decimal Price, SubscriptionRange Range);