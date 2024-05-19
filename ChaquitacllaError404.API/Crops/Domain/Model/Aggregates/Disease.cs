using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Disease
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }


    protected Disease()
    {
        this.Name = string.Empty;
        this.Description= string.Empty;
    }
    public Disease(CreateDiseaseCommand command)
    {
        this.Name= command.Name;
        this.Description = command.Description; 
    }
}