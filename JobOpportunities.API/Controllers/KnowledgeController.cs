using JobOpportunities.Core.Features.KnowledgeFeatures.Commands;
using JobOpportunities.Core.Features.KnowledgeFeatures.Models;
using JobOpportunities.Core.Features.KnowledgeFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KnowledgeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KnowledgeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IEnumerable<GetAllKnowledgeResponse>> Get() => await _mediator.Send(new GetAllKnowledgeQuery());

        [HttpGet("{id}")]
        public async Task<GetKnowledgeResponse> Get(Guid id) => await _mediator.Send(new GetKnowledgeQuery { KnowledgeId = id });

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateKnowledgeCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
