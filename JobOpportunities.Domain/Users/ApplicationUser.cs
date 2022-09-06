using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Domain
{
    public abstract class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ICollection<RefreshToken> AccessTokens { get; set; } = new HashSet<RefreshToken>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
