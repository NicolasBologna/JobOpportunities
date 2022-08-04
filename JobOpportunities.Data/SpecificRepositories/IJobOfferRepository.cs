using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories
{
    public interface IJobOfferRepository : IGenericRepository<JobOffer>
    {
        Task<ICollection<Skill>?> GetAllRequiredSkills(Guid jobOfferId);
    }
}