using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using System.Collections.Generic;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Control
{
    public int Id { get; }
    
    public int SowingId { get; private set; }
    
    public Sowing Sowing { get; private set; }
    
    public ESowingCondition Condition { get; private set; }
    
    public ESowingSoilMoisture SoilMoisture { get; private set; }
    
    public ESowingStemCondition StemCondition { get; private set; }
    
    public Control(int Id, ESowingCondition Condition, ESowingSoilMoisture SoilMoisture, ESowingStemCondition StemCondition)
    {
        this.Id = Id;
        this.Condition = Condition;
        this.SoilMoisture = SoilMoisture;
        this.StemCondition = StemCondition;
    }
    public Control(CreateControlCommand command)
    {
        SowingId = command.SowingId;
        Condition = command.Condition;
        SoilMoisture = command.SoilMoisture;
        StemCondition = command.StemCondition;
    }
    
    public Control(){}
    
}