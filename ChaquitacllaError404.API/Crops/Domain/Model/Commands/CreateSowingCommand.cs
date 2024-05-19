namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateSowingCommand(DateTime StartDate, DateTime EndDate,int AreaLand);