using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;



public record CreateCropCommand(string Name, string ImageUrl, string Description, List<int> Diseases, List<int> Pests, List<int> Cares);
