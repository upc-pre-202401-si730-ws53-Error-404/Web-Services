using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record ControlResource(
    int Id,
    int SowingId,
    ESowingCondition SowingCondition,
    ESowingSoilMoisture SowingSoilMoisture,
    ESowingStemCondition SowingStemCondition);
