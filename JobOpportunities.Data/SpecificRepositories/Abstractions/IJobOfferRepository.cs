using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        Task<IEnumerable<JobOffer>> GetActiveJobOffersByCompanyAgent(string companyAgentId);
        Task<IEnumerable<JobOffer>> GetAllJobOffersByCompanyAgent(string companyAgentId);
        Task<IEnumerable<Skill>?> GetAllRequiredSkills(Guid jobOfferId);
        Task<JobOffer?> GetWithRequiredSkills(Guid jobOfferId);
    }
}