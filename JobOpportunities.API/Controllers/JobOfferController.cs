using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobOpportunities.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IRepository<JobOffer> _jobOfferRepository;

        public JobOfferController(IRepository<JobOffer> jobOfferRepository)
        {
            _jobOfferRepository = jobOfferRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JobOffer>>> Get()
        {
            var jobOffers = await _jobOfferRepository.GetAllAsync();
            return Ok(jobOffers);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
