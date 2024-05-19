namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateSowing(DateOnly StartDate, DateOnly EndDate,int AreaLand);