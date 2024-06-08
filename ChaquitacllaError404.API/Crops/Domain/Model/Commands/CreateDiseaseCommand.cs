namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateDiseaseCommand(string Name, string Description, List<int> CropIds);