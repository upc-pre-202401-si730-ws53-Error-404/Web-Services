using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ISowingCommandService
{
    Task<Sowing> Handle(CreateSowingCommand command);
    Task<Sowing> Handle(int id, UpdateSowingCommand command);
    Task<Sowing> Handle(UpdateSowingPhenologicalPhaseCommand command);
}