using JobOpportunities.API.Controllers;
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
    public class AuthController : ApiControllerBase
    {
        [HttpPost("token")]
        public async Task<ActionResult<TokenCommandResponse>> Auth(TokenCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("claims")]
        [Authorize]
        public async Task<ActionResult<TokenInfoQueryResponse>> PersonalInformation()
        {
            return await Mediator.Send(new TokenInfoQuery());
        }

        [HttpGet("me")]
        [Authorize]
        public ActionResult<TokenInfoQueryResponse> Me([FromServices] ICurrentUserService currentUser)
        {
            return Ok(new
            {
                currentUser.User,
                IsAdmin = currentUser.IsInRole("Admin")
            });
        }

        [HttpPost("refresh")]
        public Task<RefreshTokenCommandResponse> RefreshToken([FromBody] RefreshTokenCommand command)
        {
            return Mediator.Send(command);
        }
    }


}