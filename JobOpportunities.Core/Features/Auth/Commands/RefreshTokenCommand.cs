using JobOpportunities.Core.Common.Services;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.Auth.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JobOpportunities.Core.Features.Auth.Commands;

public class RefreshTokenCommand : IRequest<RefreshTokenCommandResponse>
{
    public string AccessToken { get; set; } = default!;
    public Guid RefreshToken { get; set; } = default!;
}

public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, RefreshTokenCommandResponse>
{
    private readonly IGenericRepository<RefreshToken> _refreshTokenRepository;
    private readonly IAuthService _authService;
    private readonly ILogger<RefreshTokenCommand> _logger;
    private readonly UserManager<ApplicationUser> _userManager;

    public RefreshTokenCommandHandler(IGenericRepository<RefreshToken> refreshTokenRepository,
        IAuthService authService,
        ILogger<RefreshTokenCommand> logger,
        UserManager<ApplicationUser> userManager)
    {
        _refreshTokenRepository = refreshTokenRepository;
        _authService = authService;
        _logger = logger;
        _userManager = userManager;
    }

    public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var refreshToken = await _refreshTokenRepository.FindByConditionAsync(q => q.RefreshTokenValue == request.RefreshToken);

        // Refresh token no existe, expiró o fue revocado manualmente
        // (Pensando que el usuario puede dar click en "Cerrar Sesión en todos lados" o similar)
        if (refreshToken is null ||
            refreshToken.Active == false ||
            refreshToken.Expiration <= DateTime.UtcNow)
        {
            throw new ForbiddenAccessException();
        }

        // Se está intentando usar un Refresh Token que ya fue usado anteriormente,
        // puede significar que este refresh token fue robado.
        if (refreshToken.Used)
        {
            _logger.LogWarning("El refresh token del {UserId} ya fue usado. RT={RefreshToken}", refreshToken.UserId, refreshToken.RefreshTokenValue);

            var refreshTokens = await _refreshTokenRepository
                .FindAllByConditionAsync(q => q.Active && q.Used == false && q.UserId == refreshToken.UserId);

            foreach (var rt in refreshTokens)
            {
                rt.Used = true;
                rt.Active = false;
            }

            await _refreshTokenRepository.SaveAsync(cancellationToken);

            throw new ForbiddenAccessException();
        }

        // TODO: Podríamos validar que el Access Token sí corresponde al mismo usuario

        refreshToken.Used = true;

        var user = await _userManager.FindByIdAsync(refreshToken.UserId.ToString());

        if (user is null)
        {
            throw new ForbiddenAccessException();
        }

        string jwt = await _authService.GenerateAccessToken(user);

        RefreshToken newRefreshToken = await _authService.GenerateRefreshToken(refreshToken.UserId);

        return new RefreshTokenCommandResponse
        {
            AccessToken = jwt,
            RefreshToken = newRefreshToken.RefreshTokenValue
        };
    }
}
