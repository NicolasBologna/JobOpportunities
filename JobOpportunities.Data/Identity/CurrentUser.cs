namespace JobOpportunities.Data.Identity
{
    public record CurrentUser(string Id, string UserName, bool IsAuthenticated);
}
