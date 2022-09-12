namespace JobOpportunities.Domain.Users
{
    public class CompanyAgent : ApplicationUser
    {
        public CompanyAgent(string firstName, string lastName, string cuit) : base(firstName, lastName)
        {
            Cuit = cuit;
        }

        public string Cuit { get; set; }
        public ICollection<JobOffer>? Offers { get; set; }

    }
}
