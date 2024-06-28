using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

public partial class Crop
{
    public int Id { get; private set; }
    public string Description { get; private set; }
    public string Name { get; private set; }
    
    public string ImageUrl { get; private set; }

    public List<Disease> Diseases { get; private set; }

    public List<Pest> Pests { get; private set; } 
    public List<Care> Cares  { get; private set; } 
    
    public ICollection<Sowing> Sowing { get; set; }


    protected Crop()
    {
        this.Name = string.Empty;
        this.Description = string.Empty;
        this.ImageUrl = string.Empty;
        this.Diseases = new List<Disease>(); 
        this.Pests = new List<Pest>();
        this.Pests = new List<Pest>();
    }
    public Crop(string name, string description, string imageUrl, List<Disease> diseases, List<Pest> pests, List<Care> cares)
    {
        Name = name;
        Description = description;
        ImageUrl = imageUrl;
        Diseases = diseases;
        Pests = pests;
        Cares = cares;
    }
    public Crop(CreateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
        this.ImageUrl = command.ImageUrl;
        this.Diseases = new List<Disease>();
        this.Pests = new List<Pest>();
        this.Cares= new List<Care>();
    }

    public Crop(UpdateCropCommand command)
    {
        this.Name = command.Name;
        this.Description = command.Description;
    }
    public void Update(string name, string description)
    {
        this.Name = name;
        this.Description = description;
    }
}