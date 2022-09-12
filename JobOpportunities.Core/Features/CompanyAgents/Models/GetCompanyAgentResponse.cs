using JobOpportunities.Domain;

namespace JobOpportunities.Core.Features.CompanyAgents.Models
{
    public class GetCompanyAgentResponse
    {
        public string Cuit { get; set; }
        public ICollection<CompanyJobOffer>? Offers { get; set; }
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class CompanyJobOffer
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime ValidUntil { get; set; }
        }
    }
}
