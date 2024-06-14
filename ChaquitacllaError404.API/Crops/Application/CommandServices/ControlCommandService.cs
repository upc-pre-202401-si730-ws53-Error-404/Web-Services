using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices;

public class ControlCommandService : IControlCommandService 
{
    private readonly IControlRepository controlRepository;
    private readonly IUnitOfWork unitOfWork;

    public ControlCommandService(IControlRepository controlRepository, IUnitOfWork unitOfWork)
    {
        this.controlRepository = controlRepository;
        this.unitOfWork = unitOfWork;
    }
    
    public async Task<Control> Handle(CreateControlCommand command)
    {
        var control = new Control(command);
        try
        {
            await controlRepository.AddAsync(control);
            await unitOfWork.CompleteAsync();
            return control;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Control", e);
        }
    }
}