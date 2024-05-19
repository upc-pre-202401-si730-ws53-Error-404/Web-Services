using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ICareCommandService
{
    Task<Care> Handle(CreateCareCommand command);
}