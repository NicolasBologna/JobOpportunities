namespace JobOpportunities.Domain
{
    public class Candidate : ApplicationUser
    {
        public ICollection<Skill> Skills { get; set; } = new List<Skill>();
        public ICollection<JobOffer> OffersApplied { get; set; } = new List<JobOffer>();
    }
}
