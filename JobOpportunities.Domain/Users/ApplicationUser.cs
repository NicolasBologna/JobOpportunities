using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Domain
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public ICollection<RefreshToken> AccessTokens { get; set; } = new HashSet<RefreshToken>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserType { get; set; }
    }
}
