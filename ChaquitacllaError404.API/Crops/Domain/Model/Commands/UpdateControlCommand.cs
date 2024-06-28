using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public record UpdateControlCommand(int Id, int SowingId, ESowingCondition SowingCondition, ESowingStemCondition StemCondition, ESowingSoilMoisture SoilMoisture);