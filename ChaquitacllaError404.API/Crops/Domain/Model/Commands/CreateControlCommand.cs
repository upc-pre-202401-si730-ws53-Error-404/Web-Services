using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record CreateControlCommand(ESowingCondition Condition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition, int SowingId);