using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain.Users;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.CompanyAgents.Commands
{
    public class RemoveCompanyAgentCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class RemoveCompanyAgentCommandHandler : IRequestHandler<RemoveCompanyAgentCommand, Unit>
    {
        private readonly ICompanyAgentRepository _companyRepo;

        public RemoveCompanyAgentCommandHandler(ICompanyAgentRepository companyRepo)
        {
            _companyRepo = companyRepo;
        }
        public async Task<Unit> Handle(RemoveCompanyAgentCommand request, CancellationToken cancellationToken)
        {
            var companyToRemove = await _companyRepo.GetByIdAsync(request.Id);
            if (companyToRemove is null)
                throw new NotFoundException(nameof(companyToRemove), request.Id);

            _companyRepo.Remove(companyToRemove);
            if (await _companyRepo.SaveAsync(cancellationToken))
                return new Unit();

            throw new Exception("Hubo un error al eliminar la compañía");


        }
    }
}
