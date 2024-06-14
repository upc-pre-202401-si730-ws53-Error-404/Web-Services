using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using System.Collections.Generic;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Controls
{
    public int Id { get; }
    
    public int SowingId { get; private set; }
    
    public Sowing Sowing { get; private set; }
    
    public ESowingCondition SowingCondition{ get; private set; }
    
    public ESowingSoilMoisture SoilMoisture { get; private set; }
    
    public ESowingStemCondition StemCondition { get; private set; }
    
    public Controls()
    {
    }
    public Controls(CreateControlCommand command)
    {
        SowingId = command.SowingId;
        SowingCondition = command.SowingCondition;
        SoilMoisture = command.SoilMoisture;
        StemCondition = command.StemCondition;
    }
    
}