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
    public class UserController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<GetUserQueryResponse>> Get(Guid id)
        {
            var result = await Mediator.Send(new GetUserQuery() { Id = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register(CreateUserCommand command)
        {
            var newUserId = await Mediator.Send(command);
            return Ok(newUserId);
        }

        [HttpGet()]
        public async Task<ActionResult<GetUserQueryResponse>> Get()
        {
            var result = await Mediator.Send(new GetUsersQuery());
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

            var newUserId = await Mediator.Send(command);
            return Ok(newUserId);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Remove(Guid id)
        {
            await Mediator.Send(new RemoveCompanyAgentCommand() { Id = id });
            return NoContent();
        }
    }
}
