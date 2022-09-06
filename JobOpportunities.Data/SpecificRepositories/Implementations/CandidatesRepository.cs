using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories
{
    public class CandidatesRepository : ICandidatesRepository
    {
        public async Task<IEnumerable<Candidate>> GetallWithSkills()
        {
            throw new NotImplementedException();//return await _dbSet.Include(c => c.Skills).ToListAsync();
        }
    }
}
