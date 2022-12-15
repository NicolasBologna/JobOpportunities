using JobOpportunities.Domain;

namespace JobOpportunities.Core.Features.Skills.Models
{
    public class GetSkillResponse
    {
        public Knowledge Knowleadge { get; set; }
        public Seniority Seniority { get; set; }
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
        public ICollection<JobOffer> JobOffers { get; set; } = new List<JobOffer>();
    }
}