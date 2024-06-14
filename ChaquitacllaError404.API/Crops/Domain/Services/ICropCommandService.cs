using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ICropCommandService
{
    Task<Crop> Handle(CreateCropCommand command);
    
    Task<Crop> Handle(int id, UpdateCropCommand command);
}