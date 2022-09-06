using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;

namespace JobOpportunities.Core.Common.Services
{
    public interface IAuthService
    {
        Task<string> GenerateAccessToken(ApplicationUser user);

        Task<RefreshToken> GenerateRefreshToken(Guid userId);
    }
}