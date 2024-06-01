using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Disease
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<Crop> Crops { get; set; }
    
    public Disease(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Disease(CreateDiseaseCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }
}