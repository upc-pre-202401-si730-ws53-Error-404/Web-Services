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

    public async Task<Sowing> Handle(int id, UpdateSowingCommand command)
    {
        var sowing = await sowingRepository.FindByIdAsync(id);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        sowing.Update(command.AreaLand, command.CropId);

        try
        {
            await sowingRepository.UpdateAsync(sowing);
            await unitOfWork.CompleteAsync();
            return sowing;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the sowing", e);
        }
    }

    /**
     * Handle method to delete a sowing
     */
    
    public async Task<bool> Handle(DeleteSowingCommand command)
    {
        var sowing = await sowingRepository.FindByIdAsync(command.Id);
        if (sowing == null)
        {
            throw new Exception("Sowing not found");
        }

        try
        {
            sowingRepository.Remove(sowing);
            await unitOfWork.CompleteAsync();
            return true;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to delete the sowing", e);
        }
    }

}