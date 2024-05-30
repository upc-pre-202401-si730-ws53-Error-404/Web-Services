using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Interfaces.Resources;

public record SowingResource(int Id,DateTime StartDate, DateTime EndDate, int AreaLand, bool Status,PhenologicalPhase PhenologicalPhase);

