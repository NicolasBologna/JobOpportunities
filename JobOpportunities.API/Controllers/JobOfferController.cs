using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Core.Features.JobOffers.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<GetJobOffersResponse>> Get() => await _mediator.Send(new GetJobOffersQuery());
        [HttpGet("{id}")]
        public async Task<GetJobOfferResponse> Get(Guid id) => await _mediator.Send(new GetJobOfferQuery { JobOfferId = id });

        [HttpPost]
        public async Task<IActionResult> Post(CreateJobOfferCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
