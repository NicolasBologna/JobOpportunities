using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Data.SpecificRepositories.Implementations
{
    public class CompanyAgentRepository : ICompanyAgentRepository
    {
        private readonly JobOpportunitiesContext _dbContext;
        protected readonly DbSet<CompanyAgent> _dbSet;

        public CompanyAgentRepository(JobOpportunitiesContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<CompanyAgent>();
        }

        public async Task<CompanyAgent?> GetByIdAsync(Guid id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(CompanyAgent companyAgent)
        {
            _dbSet.Remove(companyAgent);
        }

        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
