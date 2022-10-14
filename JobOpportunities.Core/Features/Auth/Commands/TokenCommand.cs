using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Common.Services;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.Auth.Models;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace JobOpportunities.Core.Features.Auth.Commands
{
    [AuditLog]
    public class TokenCommand : IRequest<TokenCommandResponse>
    {
        [DefaultValue("test.demo")]
        public string UserName { get; set; } = default!;
        [DefaultValue("P@ss.W0rd")]
        public string Password { get; set; } = default!;
    }

    public class TokenCommandHandler : IRequestHandler<TokenCommand, TokenCommandResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthService _authService;

        public TokenCommandHandler(UserManager<ApplicationUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }
        public async Task<TokenCommandResponse> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user is null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                throw new UnauthorizedException();
            }
            var jwt = await _authService.GenerateAccessToken(user);
            var newRefreshToken = await _authService.GenerateRefreshToken(user.Id);

            return new TokenCommandResponse
            {
                IsAuthSuccessful = true,
                AccessToken = jwt,
                RefreshToken = newRefreshToken.RefreshTokenValue
            };
        }
    }
}
