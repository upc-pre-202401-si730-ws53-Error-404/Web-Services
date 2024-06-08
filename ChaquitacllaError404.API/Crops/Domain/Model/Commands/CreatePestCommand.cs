namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreatePestCommand(string Name, string Description, List<int> CropIds);