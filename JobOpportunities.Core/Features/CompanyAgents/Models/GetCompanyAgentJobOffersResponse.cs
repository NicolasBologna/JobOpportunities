using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.CompanyAgents.Models
{
    public class GetCompanyAgentJobOffersResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public ICollection<GetSkillsResponse> RequiredSkills { get; set; } = new List<GetSkillsResponse>();
    }
}
