using JobOpportunities.Domain.Relationships;
using JobOpportunities.Domain.Users;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobOpportunities.Domain
{
    public class JobOffer : EntityBase
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        [ForeignKey("CompanyId")]
        public CompanyAgent Company { get; set; }
        public Guid CompanyId { get; set; }
        public ICollection<Skill> RequiredSkills { get; set; } = new List<Skill>();
        public ICollection<Candidate> Candidates { get; set; } = new List<Candidate>();
    }
}
