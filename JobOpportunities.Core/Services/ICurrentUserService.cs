namespace JobOpportunities.Core.Services
{
    public interface ICurrentUserService
    {
        CurrentUser User { get; }

        bool IsInRole(string roleName);
    }
}