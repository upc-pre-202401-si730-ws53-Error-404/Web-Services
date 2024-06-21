using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;


//,List<Disease> Diseases, List<Pest> Pests
public record CreateCropCommand(string Name, string ImageUrl,string Description);
