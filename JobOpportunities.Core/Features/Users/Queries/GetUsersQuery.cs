using AutoMapper;
using JobOpportunities.Core.Features.Users.Models;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.Users.Queries
{
    public class GetUsersQuery : IRequest<List<GetUsersQueryResponse>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<GetUsersQueryResponse>>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public Task<List<GetUsersQueryResponse>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var user = _userManager.Users.ToList();
            return Task.FromResult(_mapper.Map<List<GetUsersQueryResponse>>(user));
        }
    }
}
