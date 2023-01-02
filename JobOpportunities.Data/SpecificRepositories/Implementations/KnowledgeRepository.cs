using JobOpportunities.CommonInfrastructure;
using JobOpportunities.CommonInfrastructure.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class KnowledgeRepository : GenericRepository<Knowledge>
    {
        public KnowledgeRepository(JobOpportunitiesContext dbContext, ILogger logger) : base(dbContext, logger)
        {
        }

        public async Task<Knowledge> GetKnowledgeById(Guid id)
        {
            var IsInvalidId = !GuidHelper.IsValidGuid(id);
            if (IsInvalidId)
            {
                Console.WriteLine($"Argument Exception in GetKnowledgeById! KnowledgeId  = {id}"); //es solo para probar el test de consola
                _logger.LogError($"Argument Exception in GetKnowledgeById! KnowledgeId  = {id}");
                throw new ArgumentException("invalid argument provided");
            }
            return await _dbContext.Knowleadges.FirstOrDefaultAsync(c => c.Id == id) ?? throw new KnowledgeNotFoundException();
        }
    }
}
