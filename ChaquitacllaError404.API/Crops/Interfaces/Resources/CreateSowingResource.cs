namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record CreateSowingResource(DateOnly StartDate, DateOnly EndDate, int AreaLand);