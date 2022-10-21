using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Core.Features.CompanyAgents.Queries;
using JobOpportunities.Domain;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    public class CompanyAgentController : ApiControllerBase
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<GetCompanyAgentResponse>> Get(Guid id)
        {
            var result = await Mediator.Send(new GetCompanyAgentQuery() { CompanyAgentId = id });
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<string>> Register(CreateCompanyAgentCommand command)
        {
            var newCompanyAgentId = await Mediator.Send(command);
            return Ok(newCompanyAgentId);
        }

        [HttpGet()]
        public async Task<ActionResult<GetCompanyAgentsResponse>> Get()
        {
            var result = await Mediator.Send(new GetCompanyAgentsQuery());
            return Ok(result);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCompanyAgentCommand command)
        {
            //Good practice from https://github.com/jasontaylordev/CleanArchitecture/blob/main/src/WebUI/Controllers/TodoItemsController.cs
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(Guid id)
        {
            await Mediator.Send(new RemoveCompanyAgentCommand() { Id = id });
            return NoContent();
        }

        [HttpGet("joboffer")]
        public async Task<ActionResult<GetCompanyAgentResponse>> GetMyJobOffers()
        {
            var result = await Mediator.Send(new GetCompanyAgentJobOffersQuery() { });
            return Ok(result);
        }
    }
}
