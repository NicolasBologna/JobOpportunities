namespace JobOpportunities.Domain
{
    public class Skill : EntityBase
    {
        public Skill(Guid seniorityId, Guid knowleadgeId)
        {
            SeniorityId = seniorityId;
            KnowleadgeId = knowleadgeId;
        }
        public Skill()
        {

        }
        public Knowledge Knowleadge { get; set; }
        public Guid KnowleadgeId { get; set; }
        public Seniority Seniority { get; set; }
        public Guid SeniorityId { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
