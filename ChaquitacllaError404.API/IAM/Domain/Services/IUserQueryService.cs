using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;
using ChaquitacllaError404.API.IAM.Domain.Model.Queries;

namespace ChaquitacllaError404.API.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}