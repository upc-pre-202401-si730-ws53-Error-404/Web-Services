namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateCareCommand(string Description, DateOnly Date, int SowingId);