namespace ChaquitacllaError404.API.Users.Domain.Model.Commands;

public record CreateSubscriptionCommand(string Description, int Price, int UserId);