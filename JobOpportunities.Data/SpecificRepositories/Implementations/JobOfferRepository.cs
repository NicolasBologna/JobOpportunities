using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class JobOfferRepository : GenericRepository<JobOffer>, IJobOfferRepository
    {
        public JobOfferRepository(JobOpportunitiesContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Skill>?> GetAllRequiredSkills(Guid jobOfferId)
        {
            var jobOffer = await _dbSet.Include(jo => jo.RequiredSkills).SingleOrDefaultAsync(jo => jo.Id == jobOfferId);

            if (jobOffer is not null)
                return jobOffer.RequiredSkills;

            return null;
        }
    }
}
