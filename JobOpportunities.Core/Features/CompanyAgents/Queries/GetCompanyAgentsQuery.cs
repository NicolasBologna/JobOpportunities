using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.CompanyAgents.Queries
{
    public class GetCompanyAgentsQuery : IRequest<List<GetCompanyAgentsResponse>>
    {
    }

    public class GetCompanyAgentsQueryHandler : IRequestHandler<GetCompanyAgentsQuery, List<GetCompanyAgentsResponse>>
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<CompanyAgent> _repo;
        private readonly IMapper _mapper;

        public GetCompanyAgentsQueryHandler(Microsoft.AspNetCore.Identity.UserManager<CompanyAgent> repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<List<GetCompanyAgentsResponse>> Handle(GetCompanyAgentsQuery request, CancellationToken cancellationToken)
        {
            var items = _repo.Users.ToList();

            return _mapper.Map<List<GetCompanyAgentsResponse>>(items);
        }
    }
}
