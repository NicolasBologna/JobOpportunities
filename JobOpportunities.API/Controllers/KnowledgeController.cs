using JobOpportunities.Core.Features.KnowledgeFeatures.Commands;
using JobOpportunities.Core.Features.KnowledgeFeatures.Models;
using JobOpportunities.Core.Features.KnowledgeFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobOpportunities.API.Controllers
{
    public class KnowledgeController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<GetAllKnowledgeResponse>> Get()
        {
            return await Mediator.Send(new GetAllKnowledgeQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetKnowledgeResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetKnowledgeQuery { KnowledgeId = id });
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateKnowledgeCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
