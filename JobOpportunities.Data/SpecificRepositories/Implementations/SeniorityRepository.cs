using JobOpportunities.CommonInfrastructure;
using JobOpportunities.CommonInfrastructure.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class SeniorityRepository : GenericRepository<Seniority>, ISeniorityRepository
    {
        public SeniorityRepository(JobOpportunitiesContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public async Task<Seniority> GetSenioritylByName(string name)
        {
            var IsInvalidName = StringHelper.IsInvalidCustomerName(name);
            if (IsInvalidName)
            {
                throw new SeniorityNotFoundException();
            }
            return await _dbContext.Senirorities.FirstOrDefaultAsync(c => c.Name == name) ?? throw new SeniorityNotFoundException();
        }
    }
}
