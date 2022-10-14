namespace JobOpportunities.Domain
{
    public class Candidate : ApplicationUser
    {
        public Candidate(string firstName, string lastName) : base(firstName, lastName)
        {
        }

        public string Cuil { get; set; }
        public byte[]? Curriculum { get; set; }

        public ICollection<Skill>? Skills { get; set; } = new List<Skill>();
        public ICollection<JobOffer> JobOfferApplications { get; set; } = new List<JobOffer>();
    }
}
