using JobOpportunities.Domain.Users;

namespace JobOpportunities.Data.SpecificRepositories.Abstractions
{
    public interface ICompanyAgentRepository
    {
        Task<CompanyAgent?> GetByIdAsync(Guid id);
        void Remove(CompanyAgent companyAgent);
        Task<bool> SaveAsync(CancellationToken cancellationToken);
    }
}