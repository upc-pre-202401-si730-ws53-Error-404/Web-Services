using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Care
{
    public int Id { get; }

    public string description { get; private set; }
    
    public DateTime date { get; private set; }
    
    public List<Crop> Crops { get; set; }

    public Care()
    {
        
    }
    
    public Care(string description, DateTime date)
    {
       this.description = description;
       this.date = date;
    }
    
}