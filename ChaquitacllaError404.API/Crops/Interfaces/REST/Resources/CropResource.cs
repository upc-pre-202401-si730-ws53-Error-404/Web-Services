namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record CropResource(int Id, string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);