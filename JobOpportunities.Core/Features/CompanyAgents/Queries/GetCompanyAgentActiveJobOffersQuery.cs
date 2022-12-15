using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.CompanyAgents.Queries
{
    public class GetCompanyAgentActiveJobOffersQuery : IRequest<IEnumerable<GetCompanyAgentJobOffersResponse>>
    {
    }

    public class GetCompanyAgentActiveJobOffersQueryHandler : IRequestHandler<GetCompanyAgentJobOffersQuery, IEnumerable<GetCompanyAgentJobOffersResponse>>
    {
        private readonly IJobOfferRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCompanyAgentActiveJobOffersQueryHandler(IJobOfferRepository repo, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<IEnumerable<GetCompanyAgentJobOffersResponse>> Handle(GetCompanyAgentJobOffersQuery request, CancellationToken cancellationToken)
        {

            var items = await _repo.GetActiveJobOffersByCompanyAgent(_currentUserService.User.Id);

            return _mapper.Map<IEnumerable<GetCompanyAgentJobOffersResponse>>(items);
        }
    }
}
