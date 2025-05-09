namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record AddProductToSowingCommand(
    int SowingId,
    int ProductId,
    int Quantity,
    DateTime UseDate
    );