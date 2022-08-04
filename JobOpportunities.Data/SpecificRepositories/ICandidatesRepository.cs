using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories
{
    public interface ICandidatesRepository : IGenericRepository<Candidate>
    {
        Task<IEnumerable<Candidate>> GetallWithSkills();
    }
}