using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using System;

namespace ChaquitacllaError404.API.Crops.Application.CommandServices
{
    public class ControlCommandService : IControlCommandService
    {
        private readonly IControlRepository controlRepository;
        private readonly ISowingRepository sowingRepository;

        public ControlCommandService(IControlRepository controlRepository, ISowingRepository sowingRepository)
        {
            this.controlRepository = controlRepository;
            this.sowingRepository = sowingRepository;
        }

        public async Task<int> Handle(CreateControlCommand command)
        {
            var sowing = await sowingRepository.FindByIdAsync(command.SowingId);

            if (sowing == null)
                throw new ArgumentException($"Sowing with id {command.SowingId} does not exist");

            var control = new Control(command.SowingId, command.Condition, command.SoilMoisture,
                command.StemCondition);
            await controlRepository.SaveAsync(control);
            return control.Id;
        }

        public async Task Handle(DeleteControlCommand command)
        {
            var exists = await controlRepository.ExistsByIdAsync(command.SowingId);

            if (!exists)
                throw new ArgumentException("Control does not exist");

            await controlRepository.DeleteByIdAsync(command.SowingId);
        }
    }
}