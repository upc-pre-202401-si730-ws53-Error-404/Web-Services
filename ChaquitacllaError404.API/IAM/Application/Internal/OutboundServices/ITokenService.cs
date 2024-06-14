using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;

namespace ChaquitacllaError404.API.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}