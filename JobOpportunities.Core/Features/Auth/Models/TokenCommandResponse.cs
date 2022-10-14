namespace JobOpportunities.Core.Features.Auth.Models
{
    public class TokenCommandResponse
    {
        public bool IsAuthSuccessful { get; set; }
        public string AccessToken { get; set; } = default!;
        public Guid RefreshToken { get; set; } = default!;
    }
}
