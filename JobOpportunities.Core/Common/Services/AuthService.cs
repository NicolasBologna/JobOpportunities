using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JobOpportunities.Core.Common.Services;

public class AuthService : IAuthService
{
    private readonly IConfiguration _config;
    private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
    private readonly IGenericRepository<RefreshToken> _refreshTokenRepository;

    public AuthService(IConfiguration config, Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> userManager, IGenericRepository<RefreshToken> refreshTokenRepository)
    {
        _config = config;
        _userManager = userManager;
        _refreshTokenRepository = refreshTokenRepository;
    }

    public async Task<string> GenerateAccessToken(ApplicationUser user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Sid, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        claims.Add(new Claim(ClaimTypes.Role, user.UserType));

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    public async Task<RefreshToken> GenerateRefreshToken(Guid userId)
    {

        var newRefreshToken = new RefreshToken
        {
            Active = true,
            Expiration = DateTime.UtcNow.AddDays(7),
            RefreshTokenValue = Guid.NewGuid(),
            Used = false,
            UserId = userId,
        };

        _refreshTokenRepository.Add(newRefreshToken);

        await _refreshTokenRepository.SaveAsync();

        return newRefreshToken;
    }
}
