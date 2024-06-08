using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices
{
    public class ControlQueryService : IControlQueryService
    {
        private readonly IControlRepository controlRepository;

        public ControlQueryService(IControlRepository controlRepository)
        {
            this.controlRepository = controlRepository;
        }

        public async Task<List<Control>> Handle(GetAllControlsQuery query)
        {
            return await controlRepository.GetAllAsync();
        }

        public async Task<List<Control>> Handle(GetAllControlsBySowingIdQuery query)
        {
            return await controlRepository.GetBySowingIdAsync(query.SowingId);
        }

        public async Task<Control> Handle(GetControlByIdQuery query)
        {
            return await controlRepository.GetByIdAsync(query.Id);
        }
    }
}