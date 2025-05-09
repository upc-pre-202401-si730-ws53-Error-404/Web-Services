namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record CreateCropResource(string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);