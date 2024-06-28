using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

public record UpdateControlResource(ESowingCondition SowingCondition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition);