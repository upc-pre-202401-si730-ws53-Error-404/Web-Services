namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record CreateDiseaseResource(string Name, string Description, List<int> CropIds);