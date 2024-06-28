using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices;

public class PestCommandService(IPestRepository pestRepository, IUnitOfWork unitOfWork)
    : IPestCommandService
{
    public async Task<Pest> Handle(CreatePestCommand command)
    {
        var pest = new Pest
        {
            Name = command.Name,
            Description = command.Description,
            Solution = command.Solution,
        };
        
        try
        {
            await pestRepository.AddAsync(pest);
            await unitOfWork.CompleteAsync();
            return pest;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Pest", e);
        }
    }
}