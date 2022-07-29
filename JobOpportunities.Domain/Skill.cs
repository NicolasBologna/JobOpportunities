namespace JobOpportunities.Domain
{
    public class Skill : EntityBase
    {
        public Knowleadge Knowleadge { get; set; }
        public Guid KnowleadgeId { get; set; }
        public SkillLevel SkillLevel { get; set; }
        public Guid SkillLevelId { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}
