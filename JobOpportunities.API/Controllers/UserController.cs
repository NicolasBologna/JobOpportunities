using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Core.Features.Users.Commands;
using JobOpportunities.Core.Features.Users.Models;
using JobOpportunities.Core.Features.Users.Queries;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediatr;

        public UserController(IMediator mediatr)
        {
            _mediatr = mediatr;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserQueryResponse>> Get(Guid id)
        {
            var result = await _mediatr.Send(new GetUserQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register(CreateUserCommand command)
        {
            var newUserId = await _mediatr.Send(command);
            return Ok(newUserId);
        }

        [HttpGet()]
        public async Task<ActionResult<GetUserQueryResponse>> Get()
        {
            var result = await _mediatr.Send(new GetUsersQuery());
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<string>> Update(Guid id, UpdateUserCommand command)
        {
            //Good practice from https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/WebUI/Controllers/TodoItemsController.cs
            if (id.ToString() != command.Id)
            {
                return BadRequest();
            }

            var newUserId = await _mediatr.Send(command);
            return Ok(newUserId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove(Guid id)
        {
            await _mediatr.Send(new RemoveCompanyAgentCommand() { Id = id });
            return NoContent();
        }
    }
}
