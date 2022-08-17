namespace JobOpportunities.Domain
{
    public class Candidate : ApplicationUser
    {
        public Candidate(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<JobOffer> OffersApplied { get; set; } = new List<JobOffer>();
    }
}
