using JobOpportunities.Core.Features.SkillLevels.Commands;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Core.Features.SkillLevels.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillLevelController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillLevelController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetSkillLevelsResponse>> Get() => await _mediator.Send(new GetSkillLevelsQuery());

        [HttpGet("{id}")]
        public async Task<GetSkillLevelResponse> Get(Guid id) => await _mediator.Send(new GetSkillLevelQuery { SkillLevelId = id });

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillLevelCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
