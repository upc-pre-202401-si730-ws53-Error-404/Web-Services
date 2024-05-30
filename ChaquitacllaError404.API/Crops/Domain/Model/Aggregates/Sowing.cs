using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Sowing
{
    public int Id { get; private set; }
    public DateTime StartDate { get; private set; } 
    public DateTime EndDate { get; private set; }
    public int AreaLand { get; private set; }
    public bool Status { get; private set; }
    
    public PhenologicalPhase PhenologicalPhase { get; private set; }

    public Sowing()
    {
        this.StartDate = DateTime.Now;
        this.EndDate = DateTime.MinValue;
        this.AreaLand = 0;
        this.Status = false;
        this.PhenologicalPhase = PhenologicalPhase.Germination; 
    }
 

    public Sowing(CreateSowingCommand command)
    {
        this.StartDate = DateTime.Now;
        this.EndDate = this.StartDate.AddMonths(6); 
        this.AreaLand = command.AreaLand;
        this.PhenologicalPhase = PhenologicalPhase.Germination; 
    }
}