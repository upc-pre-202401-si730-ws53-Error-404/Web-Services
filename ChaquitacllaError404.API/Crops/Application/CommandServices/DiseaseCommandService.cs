using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using System;
using System.Threading.Tasks;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices
{
    public class DiseaseCommandService(IDiseaseRepository diseaseRepository, IUnitOfWork unitOfWork) : IDiseaseCommandService
    {
      public async Task<Disease> Handle(CreateDiseaseCommand command)
        {
            var disease = new Disease
            {
                Name = command.Name,
                Description = command.Description,
                CropsDiseases = new List<CropsDiseases>()
            };

            foreach (var cropId in command.CropIds)
            {
                var cropsDiseases = new CropsDiseases
                {
                    CropId = cropId,
                    Disease = disease
                };

                disease.CropsDiseases.Add(cropsDiseases);
            }

            try
            {
                await diseaseRepository.AddAsync(disease);
                await unitOfWork.CompleteAsync();
                return disease;
            }
            catch (Exception e)
            {
                throw new Exception("An error occurred while trying to add the new Disease", e);
            }
        }
    }
}