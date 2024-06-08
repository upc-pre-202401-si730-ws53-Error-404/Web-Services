using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class CropsPests
{
    public int CropId { get; set; }
    
    public Crop Crop { get; set; }
    public int PestId { get; set; }
    
    public Pest Pest { get; set; }
}