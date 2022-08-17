namespace JobOpportunities.Core.Features.Auth.Models;

public class RefreshTokenCommandResponse
{
    public string AccessToken { get; set; } = default!;
    public Guid RefreshToken { get; set; } = default!;
}
