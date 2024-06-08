using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class CropsDiseases
{
    public int CropId { get; set; }
    public Crop Crop { get; set; } 

    public int DiseaseId { get; set; }
    public Disease Disease { get; set; } 
}