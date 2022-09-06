using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface ICandidatesRepository
    {
        Task<IEnumerable<Candidate>> GetallWithSkills();
    }
}