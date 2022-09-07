using JobOpportunities.Core.Features.SkillLevels.Commands;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Core.Features.SkillLevels.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    public class SkillLevelController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetSkillLevelsResponse>> Get()
        {
            return await Mediator.Send(new GetSkillLevelsQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetSkillLevelResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetSkillLevelQuery { SkillLevelId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillLevelCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
