using JobOpportunities.Core.Features.Skills.Commands;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Core.Features.Skills.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    public class SkillController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetSkillsResponse>> Get()
        {
            return await Mediator.Send(new GetSkillsQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetSkillResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetSkillQuery { SkillId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
