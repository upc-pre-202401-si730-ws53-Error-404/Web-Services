using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices;

public class CareCommandService(ICareRepository careRepository, IUnitOfWork unitOfWork) : ICareCommandService
{
    public async Task<Care> Handle(CreateCareCommand command)
    {
        var care = new Care
        {
            Suggestion = command.suggestion,
            Date = command.date,
        };

        try
        {
            await careRepository.AddAsync(care);
            await unitOfWork.CompleteAsync();
            return care;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Care", e);
        }
    }
}
