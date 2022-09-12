using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.CompanyAgents.Queries
{
    public class GetCompanyAgentQuery : IRequest<GetCompanyAgentResponse>
    {
        public Guid CompanyAgentId { get; set; }
    }

    public class GetCompanyAgentQueryHandler : IRequestHandler<GetCompanyAgentQuery, GetCompanyAgentResponse>
    {
        private readonly UserManager<CompanyAgent> _repo;
        private readonly IMapper _mapper;

        public GetCompanyAgentQueryHandler(UserManager<CompanyAgent> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<GetCompanyAgentResponse> Handle(GetCompanyAgentQuery request, CancellationToken cancellationToken)
        {
            var item = await _repo.FindByIdAsync(request.CompanyAgentId.ToString());

            if (item is null)
            {
                throw new Exception();
            }

            return _mapper.Map<GetCompanyAgentResponse>(item);
        }
    }
}