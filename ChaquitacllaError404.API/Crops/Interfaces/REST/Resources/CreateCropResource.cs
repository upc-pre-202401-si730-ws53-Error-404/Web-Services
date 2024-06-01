namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record CreateCropResource(string Name, string Description, List<int> DiseaseIds, List<int> PestIds);