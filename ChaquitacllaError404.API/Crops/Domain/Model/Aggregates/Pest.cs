using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Pest
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }


    protected Pest()
    {
        this.Name = string.Empty;
        this.Description= string.Empty;
    }
    public Pest(CreatePestCommand command)
    {
        this.Name= command.Name;
        this.Description = command.Description; 
    }
}