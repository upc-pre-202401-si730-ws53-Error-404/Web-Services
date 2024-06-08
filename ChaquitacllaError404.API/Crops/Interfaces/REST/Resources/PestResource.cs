using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
public record PestResource(int Id, string Name, string Description, Crop[] CropIds);