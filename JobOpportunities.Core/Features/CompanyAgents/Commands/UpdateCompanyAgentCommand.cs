using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.CompanyAgents.Commands
{
    public class UpdateCompanyAgentCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class UpdateCompanyAgentCommandHandler : IRequestHandler<UpdateCompanyAgentCommand>
    {
        private readonly UserManager<CompanyAgent> _repository;
        private readonly IMapper _mapper;

        public UpdateCompanyAgentCommandHandler(UserManager<CompanyAgent> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCompanyAgentCommand request, CancellationToken cancellationToken)
        {
            var dbObject = await _repository.FindByIdAsync(request.Id.ToString());

            if (dbObject is null)
            {
                throw new NotFoundException();
            }

            _mapper.Map(request, dbObject);

            await _repository.UpdateAsync(dbObject);

            return Unit.Value;
        }
    }
}
