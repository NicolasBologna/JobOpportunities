using JobOpportunities.Domain;
using System.Linq.Expressions;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface ISkillRepository
    {
        Task CreateSkill(Guid seniorityId, Guid knowleadgeId);
        Task<IEnumerable<Skill>> FindAllByConditionWithRelatedAsync(Expression<Func<Skill, bool>> predicate);
        Task<IEnumerable<Skill>> GetallWithRelated();
    }
}