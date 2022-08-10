namespace JobOpportunities.Data.Identity;
public interface ICurrentUserService
{
    CurrentUser User { get; }

    bool IsInRole(string roleName);
}