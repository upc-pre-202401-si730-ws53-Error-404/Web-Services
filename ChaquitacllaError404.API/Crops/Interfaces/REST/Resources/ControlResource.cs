namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record ControlResource(int Id,int SowingId, DateTime Date ,string SowingCondition, string StemCondition, string SoilMoisture);
