using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(JobOpportunitiesContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Skill>> GetallWithRelated()
        {
            return await _dbSet.Include(s => s.Knowleadge).Include(s => s.SkillLevel).ToListAsync();
        }

        public async Task<IEnumerable<Skill>> FindAllByConditionWithRelatedAsync(Expression<Func<Skill, bool>> predicate)
        {
            return await _dbSet.Include(s => s.Knowleadge).Include(s => s.SkillLevel).Where(predicate).ToListAsync();
        }
    }
}
