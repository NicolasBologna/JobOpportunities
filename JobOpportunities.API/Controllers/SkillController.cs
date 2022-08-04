using JobOpportunities.Core.Features.Skills.Commands;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Core.Features.Skills.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SkillController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetSkillsResponse>> Get() => await _mediator.Send(new GetSkillsQuery());

        [HttpGet("{id}")]
        public async Task<GetSkillResponse> Get(Guid id) => await _mediator.Send(new GetSkillQuery { SkillId = id });

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateSkillCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
