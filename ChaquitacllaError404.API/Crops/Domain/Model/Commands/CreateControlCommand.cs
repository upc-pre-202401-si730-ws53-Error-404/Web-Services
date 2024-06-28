using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateControlCommand(int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition,  ESowingSoilMoisture SoilMoisture);