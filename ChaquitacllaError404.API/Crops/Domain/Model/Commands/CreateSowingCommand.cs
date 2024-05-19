namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateSowingCommand(DateOnly StartDate, DateOnly EndDate,int AreaLand);