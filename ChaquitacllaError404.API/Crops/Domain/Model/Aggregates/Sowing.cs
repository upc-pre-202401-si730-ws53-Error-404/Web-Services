using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Sowing
{
    public int Id { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public int AreaLand { get; private set; }
    public bool Status { get; private set; }
    protected Sowing()
    {
        this.StartDate = DateTime.MinValue;
        this.EndDate = DateTime.MinValue;
        this.AreaLand = 0;
        this.Status = false;
    }

    public Sowing(CreateSowingCommand command)
    {
        this.StartDate = command.StartDate;
        this.EndDate = command.EndDate;
        this.AreaLand = command.AreaLand;
    }
}