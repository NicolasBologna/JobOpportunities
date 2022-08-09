using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories
{
    public interface ICandidatesRepository
    {
        Task<IEnumerable<Candidate>> GetallWithSkills();
    }
}