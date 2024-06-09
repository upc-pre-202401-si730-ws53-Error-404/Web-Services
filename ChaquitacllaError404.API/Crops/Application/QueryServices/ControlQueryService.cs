using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class ControlQueryService (IControlRepository controlRepository) : IControlQueryService
{
    public async Task<IEnumerable<Controls>> Handle(GetAllControlsQuery query)
    {
        return await controlRepository.ListAsync();
    }
    public async Task<Controls?> Handle(GetControlByIdQuery query)
    {
        return await controlRepository.FindByIdAsync(query.Id);
    }
}