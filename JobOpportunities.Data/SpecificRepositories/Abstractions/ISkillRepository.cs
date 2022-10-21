using JobOpportunities.Domain;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface ISkillRepository
    {
        Task<IEnumerable<Skill>> GetallWithRelated();
    }
}