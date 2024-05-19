namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

public class Care
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public DateOnly Date { get; private set; }
    public int SowingId { get; private set; }

    protected Care()
    {
        this.Date = DateOnly.MinValue;
        this.Description= string.Empty;
        this.SowingId = 0;
    }

    public Care(CreateCareCommand command)
    {
        this.Date= command.Date;
        this.Description = command.Description; 
        this.SowingId = command.SowingId;
    }
}