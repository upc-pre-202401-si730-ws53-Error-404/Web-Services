using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IControlCommandService
{
    Task<int> Handle(CreateControlCommand command);
    Task Handle(DeleteControlCommand command);
}