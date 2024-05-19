using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IDiseaseCommandService
{
    Task<Disease> Handle(CreateDiseaseCommand command);
}