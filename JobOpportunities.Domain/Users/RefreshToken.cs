namespace JobOpportunities.Domain.Users
{
    public class RefreshToken : EntityBase
    {
        public RefreshToken(ApplicationUser user, string userId, Guid refreshTokenValue)
        {
            User = user;
            UserId = userId;
            RefreshTokenValue = refreshTokenValue;
        }
        public RefreshToken()
        {

        }

        public int RefreshTokenId { get; set; }
        public Guid RefreshTokenValue { get; set; }
        public bool Active { get; set; }
        public DateTime Expiration { get; set; }
        public bool Used { get; set; }
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
