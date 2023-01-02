using JobOpportunities.CommonInfrastructure;
using JobOpportunities.CommonInfrastructure.Exceptions.DBExceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq.Expressions;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(JobOpportunitiesContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public async Task<IEnumerable<Skill>> GetallWithRelated()
        {
            return await _dbSet.Include(s => s.Knowleadge).Include(s => s.Seniority).ToListAsync();
        }

        public async Task<IEnumerable<Skill>> FindAllByConditionWithRelatedAsync(Expression<Func<Skill, bool>> predicate)
        {
            return await _dbSet.Include(s => s.Knowleadge).Include(s => s.Seniority).Where(predicate).ToListAsync();
        }

        public async Task CreateSkill(Guid seniorityId, Guid knowleadgeId)
        {
            if (!GuidHelper.IsValidGuid(seniorityId) || !GuidHelper.IsValidGuid(knowleadgeId))
            {
                throw new ArgumentException("Invalid arguments provided");
            }

            Skill newSkill = new(seniorityId, knowleadgeId);

            _dbSet.Add(newSkill);
            if (!await SaveAsync())
                throw new CouldNotAddSkillToDatabaseException();

        }
    }
}
