namespace JobOpportunities.Domain.Users
{
    public class Admin : ApplicationUser
    {
        public Admin(string firstName, string lastName) : base(firstName, lastName)
        {
        }
    }
}
