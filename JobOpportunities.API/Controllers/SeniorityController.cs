using JobOpportunities.Core.Features.SkillLevels.Commands;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Core.Features.SkillLevels.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    public class SeniorityController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetSenioritiesResponse>>> Get()
        {
            return Ok(await Mediator.Send(new GetSenioritiesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<GetSeniorityResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetSeniorityQuery { SeniorityId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSeniorityLevelCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
