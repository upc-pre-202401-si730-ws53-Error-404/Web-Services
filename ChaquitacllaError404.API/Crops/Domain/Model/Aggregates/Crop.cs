using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public class Crop
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    public ICollection<Sowing> Sowings { get; private set; } // Collection of Sowings


    protected Crop()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.Sowings = new List<Sowing>();
    }
    public Crop(CreateCropCommand command)
    {
        this.Name= command.Name;
        this.Description = command.Description; 
    }
}