using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Crops.Domain.Model.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name{get;  set; }
    public EProductType Type { get;  set; }
    
    public ICollection<ProductsBySowing> ProductsBySowing { get; private set; } = [];

    private Product()
    {
        
    }
    
    public Product(CreateProductCommand command)
    {
        Name = command.Name;
        Type = command.Type;
    }
    public Product(string name, EProductType type)
    {
        Name = name;
        Type = type;
    }

    
}