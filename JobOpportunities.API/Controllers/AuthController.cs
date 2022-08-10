using JobOpportunities.Core.Features.Auth.Commands;
using JobOpportunities.Core.Features.Auth.Models;
using JobOpportunities.Core.Features.Auth.Queries;
using JobOpportunities.Data.Identity;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ConsultaAlumnos.API.Controllers
{
    [Route("api")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediatr;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthController(IMediator mediatr, UserManager<ApplicationUser> userManager, IHttpContextAccessor contextAccessor)
        {
            _mediatr = mediatr;
            _userManager = userManager;
            _contextAccessor = contextAccessor;
        }

        [HttpPost("token")]
        public async Task<ActionResult<TokenCommandResponse>> Auth(TokenCommand command) => await _mediatr.Send(command);

        [HttpGet("claims")]
        [Authorize]
        public async Task<ActionResult<TokenInfoQueryResponse>> PersonalInformation() => await _mediatr.Send(new TokenInfoQuery());

        [HttpGet("me")]
        [Authorize]
        public async Task<ActionResult<TokenInfoQueryResponse>> Me([FromServices] ICurrentUserService currentUser)
        {
            return Ok(new
            {
                currentUser.User,
                IsAdmin = currentUser.IsInRole("Admin")
            });
        }
    }


}