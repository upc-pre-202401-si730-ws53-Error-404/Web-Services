using System.Text.Json.Serialization;
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class ProductsBySowing
{
    public int SowingId { get; private set; }
    [JsonIgnore]
    public Sowing Sowing { get; private set; }
    public int ProductId { get; private set; }
    [JsonIgnore]
    public Product Product { get; private set; }
    public int Quantity { get; private set; }
    public DateTime UseDate { get; private set; }

    
    private ProductsBySowing()
    {
        
    }
    public ProductsBySowing(AddProductToSowingCommand command)
    {
        SowingId = command.SowingId;
        ProductId = command.ProductId;
        Quantity = command.Quantity;
        UseDate = DateTime.Now; 
    }
    
    
    
   
}