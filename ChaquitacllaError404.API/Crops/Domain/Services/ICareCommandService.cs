using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ICareCommandService
{
    Task<Care> Handle(CreateCareCommand command);

}