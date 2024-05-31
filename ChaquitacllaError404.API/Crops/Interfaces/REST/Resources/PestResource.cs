namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record PestResource(int Id, string Name, string Description, List<int> CropIds);