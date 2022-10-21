using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        Task<ICollection<JobOffer>> GetAllJobOffersByCompanyAgent(string companyAgentId);
        Task<ICollection<Skill>?> GetAllRequiredSkills(Guid jobOfferId);
    }
}