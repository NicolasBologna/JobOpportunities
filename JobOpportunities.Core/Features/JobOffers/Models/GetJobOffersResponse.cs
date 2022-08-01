namespace JobOpportunities.Core.Features.JobOffers.Models
{
    public class GetJobOffersResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CompanyId { get; set; }
    }
}
