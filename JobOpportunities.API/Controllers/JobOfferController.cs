using JobOpportunities.Core.Features.JobOfferMatches.Models;
using JobOpportunities.Core.Features.JobOfferMatches.Queries;
using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Core.Features.JobOffers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    public class JobOfferController : ApiControllerBase
    {
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<GetJobOffersResponse>> Get()
        {
            return await Mediator.Send(new GetJobOffersQuery());
        }

        [HttpGet("{id}")]
        public async Task<GetJobOfferResponse> Get(Guid id)
        {
            return await Mediator.Send(new GetJobOfferQuery { JobOfferId = id });
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post(CreateJobOfferCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Put(UpdateJobOfferCommand command)
        {
            await Mediator.Send(command);
            return Ok();
        }

        [HttpGet]
        [Route("{id}/potentialcandidates")]
        public async Task<IEnumerable<GetJobOfferCandidatesResponse>> GetJobOfferCandidates(Guid id)
        {
            return await Mediator.Send(new GetJobOfferCandidatesQuery { JobOfferId = id });
        }



        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
