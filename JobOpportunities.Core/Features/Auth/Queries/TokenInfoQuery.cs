using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.Auth.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace JobOpportunities.Core.Features.Auth.Queries
{
    public class TokenInfoQuery : IRequest<TokenInfoQueryResponse>
    {
    }
    public class TokenInfoQueryHandler : IRequestHandler<TokenInfoQuery, TokenInfoQueryResponse>
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public TokenInfoQueryHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }
        public Task<TokenInfoQueryResponse> Handle(TokenInfoQuery request, CancellationToken cancellationToken)
        {
            var user = _contextAccessor.HttpContext!.User;

            if (user is null)
                throw new ForbiddenAccessException();

            var response = new TokenInfoQueryResponse()
            {
                Claims = user.Claims.Select(s => new
                {
                    s.Type,
                    s.Value
                }).ToList(),
                Name = user.Identity!.Name,
                IsAuthenticated = user.Identity.IsAuthenticated,
                AuthenticationType = user.Identity.AuthenticationType
            };

            return Task.FromResult(response);
        }
    }
}
