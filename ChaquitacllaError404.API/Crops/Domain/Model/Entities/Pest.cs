using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Pest
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public List<CropsPests> CropsPests { get; set; }

    
    public Pest(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }
    public Pest(CreatePestCommand command)
    {
        Name = command.Name;
        Description = command.Description;
    }
    
    public Pest()
    {
    }
}