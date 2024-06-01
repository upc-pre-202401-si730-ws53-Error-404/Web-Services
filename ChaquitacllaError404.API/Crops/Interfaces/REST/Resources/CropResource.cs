namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record CropResource(int Id, string Name, string Description, List<int> DiseaseIds, List<int> PestIds);