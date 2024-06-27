namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record CreateDiseaseResource(string Name, string Description, string Solution, List<int> CropIds);