using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Features.JobOffers.Models
{
    public class GetJobOfferResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<GetSkillsResponse> RequiredSkills { get; set; } = new List<GetSkillsResponse>();
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
