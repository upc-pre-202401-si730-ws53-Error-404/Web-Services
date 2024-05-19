namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record SowingResource(int Id,DateOnly StartDate, DateOnly EndDate, int AreaLand, bool Status);