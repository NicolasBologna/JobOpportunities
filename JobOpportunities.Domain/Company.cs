namespace JobOpportunities.Domain
{
    public class Company : EntityBase
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public ICollection<JobOffer> Offers { get; set; } = new List<JobOffer>();
    }
}
