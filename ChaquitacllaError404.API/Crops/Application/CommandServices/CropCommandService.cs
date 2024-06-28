using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using System;
using System.Threading.Tasks;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices;

public class CropCommandService : ICropCommandService
{
    private readonly ISowingRepository sowingRepository;
    private readonly ICropRepository cropRepository;
    private readonly IUnitOfWork unitOfWork;
    private readonly IDiseaseRepository diseaseRepository;
    private readonly IPestRepository pestRepository;
    private readonly ICareRepository careRepository;
    public CropCommandService(ICropRepository cropRepository, ISowingRepository sowingRepository,
        IUnitOfWork unitOfWork, IDiseaseRepository diseaseRepository, IPestRepository pestRepository, ICareRepository careRepository)
    {
        this.cropRepository = cropRepository;
        this.sowingRepository = sowingRepository;
        this.unitOfWork = unitOfWork;
        this.diseaseRepository = diseaseRepository;
        this.pestRepository = pestRepository;
        this.careRepository = careRepository;
    }

    public async Task<Crop> Handle(CreateCropCommand command)
    {
        var diseases = command.Diseases.Select<int, Disease>(id => diseaseRepository.FindByIdAsync(id).Result ?? throw new Exception("Disease not found")).ToList();
        var pests = command.Pests.Select<int, Pest>(id => pestRepository.FindByIdAsync(id).Result ?? throw new Exception("Pest not found")).ToList();
        var cares = command.Cares.Select<int, Care>(id => careRepository.FindByIdAsync(id).Result ?? throw new Exception("Care not found")).ToList();

        var crop = new Crop(command.Name, command.Description, command.ImageUrl, diseases, pests, cares);

        try
        {
            await cropRepository.AddAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Crop", e);
        }
    }

    public async Task<Crop> Handle(int id, UpdateCropCommand command)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        crop.Update(command.Name, command.Description);

        try
        {
            await cropRepository.UpdateAsync(crop);
            await unitOfWork.CompleteAsync();
            return crop;
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to update the Crop", e);
        }
    }

    public async Task<Sowing> CreateSowingFromCrop(int id)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        var sowing = new Sowing
        {
            CropId = crop.Id
            // Inicializa otras propiedades necesarias aquí
        };

        await sowingRepository.AddAsync(sowing);
        await unitOfWork.CompleteAsync();
        return sowing;
    }

    public async Task<Crop> DeleteCrop(int id)
    {
        var crop = await cropRepository.FindByIdAsync(id);
        if (crop == null)
        {
            throw new Exception("Crop not found");
        }

        cropRepository.Remove(crop);
        await unitOfWork.CompleteAsync();

        return crop;
    }

    public async Task<Sowing> HandleCreateSowing(CreateSowingCommand createSowingCommand)
    {
        if (createSowingCommand == null)
        {
            throw new ArgumentNullException(nameof(createSowingCommand), "The provided sowing command is null.");
        }

        var sowing = new Sowing(createSowingCommand);

        try
        {
            await sowingRepository.AddAsync(sowing);
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to add the new Sowing to the repository.", e);
        }

        try
        {
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception("An error occurred while trying to save changes to the database.", e);
        }

        return sowing;
    }
}