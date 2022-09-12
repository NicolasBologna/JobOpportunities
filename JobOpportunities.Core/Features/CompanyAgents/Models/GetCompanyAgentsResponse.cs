using JobOpportunities.Domain;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.CompanyAgents.Models
{
    public class GetCompanyAgentsResponse
    {
        public string Cuit { get; set; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}
