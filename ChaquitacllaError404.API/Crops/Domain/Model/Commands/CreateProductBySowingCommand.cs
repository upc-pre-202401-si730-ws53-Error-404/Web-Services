namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateProductBySowingCommand(int SowingId, int ProductId, int Quantity, DateTime UseDate);