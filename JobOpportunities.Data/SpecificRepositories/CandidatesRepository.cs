using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Data.SpecificRepositories
{
    public class CandidatesRepository : GenericRepository<Candidate>, ICandidatesRepository
    {
        public CandidatesRepository(JobOpportunitiesContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Candidate>> GetallWithSkills()
        {
            return await _dbSet.Include(c => c.Skills).ToListAsync();
        }
    }
}
