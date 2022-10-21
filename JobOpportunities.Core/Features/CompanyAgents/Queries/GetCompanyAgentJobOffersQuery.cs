using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Data.SpecificRepositories.Implementations;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.CompanyAgents.Queries
{
    public class GetCompanyAgentJobOffersQuery : IRequest<IEnumerable<GetCompanyAgentJobOffersResponse>>
    {
    }

    public class GetCompanyAgentJobOffersQueryHandler : IRequestHandler<GetCompanyAgentJobOffersQuery, IEnumerable<GetCompanyAgentJobOffersResponse>>
    {
        private readonly IJobOfferRepository _repo;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public GetCompanyAgentJobOffersQueryHandler(IJobOfferRepository repo, IMapper mapper, ICurrentUserService currentUserService)
        {
            _repo = repo;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<IEnumerable<GetCompanyAgentJobOffersResponse>> Handle(GetCompanyAgentJobOffersQuery request, CancellationToken cancellationToken)
        {

            var item = await _repo.GetAllJobOffersByCompanyAgent(_currentUserService.User.Id);

            if (item is null)
            {
                throw new Exception();
            }

            return _mapper.Map<IEnumerable<GetCompanyAgentJobOffersResponse>>(item);
        }
    }
}
