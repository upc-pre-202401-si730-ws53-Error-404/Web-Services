using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public partial class Sowing
{
    public int Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int AreaLand { get; private set; }
    public bool Status { get; private set; }

    public EPhenologicalPhase PhenologicalPhase { get; private set; }

    public int CropId { get; set; }
    public Crop Crop { get; private set; }

    public ICollection<ProductsBySowing> ProductsBySowing { get; private set; } = [];
   
    public ICollection<Control> Controls { get; set; }

    
    public Sowing()
    {
        this.StartDate = DateTime.Now;
        this.EndDate = DateTime.MinValue;
        this.AreaLand = 0;
        this.Status = false;
        this.PhenologicalPhase = EPhenologicalPhase.Germination;
    }


    public Sowing(CreateSowingCommand command)
    {
        this.StartDate = DateTime.Now;
        this.EndDate = this.StartDate.AddMonths(6);
        this.AreaLand = command.AreaLand;
        this.PhenologicalPhase = EPhenologicalPhase.Germination;
        this.CropId = command.CropId;
    }

    public Sowing(UpdateSowingCommand command)
    {
        this.AreaLand = command.AreaLand;
        this.CropId = command.CropId;
    }
    public void Update(int areaLand, int cropId)
    {
        AreaLand = areaLand;
        CropId = cropId;
    }
    
    public void IncrementPhenologicalPhase()
    {
        if (PhenologicalPhase < EPhenologicalPhase.HarvestReady)
        {
            PhenologicalPhase++;
        }
        else
        {
            throw new InvalidOperationException("Cannot increment PhenologicalPhase beyond Harvest.");
        }
    }
}

