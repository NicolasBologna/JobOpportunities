using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
