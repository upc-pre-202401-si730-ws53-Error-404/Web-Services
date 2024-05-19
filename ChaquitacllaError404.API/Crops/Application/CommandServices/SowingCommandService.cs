using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices;

public class SowingCommandService(ISowingRepository sowingRepository, IUnitOfWork unitOfWork)
: ISowingCommandService
{

    public async Task<Sowing> Handle(CreateSowingCommand command)
    {
        var sowing = new Sowing(command);
        try
        {
            await sowingRepository.AddAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new sowing", e);
        }
    }
}