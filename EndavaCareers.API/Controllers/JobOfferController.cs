using EndavaCareers.API.Contracts;
using EndavaCareers.API.Dto;
using EndavaCareers.API.Entities;
using EndavaCareers.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EndavaCareers.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobOfferController : ControllerBase
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly IJobOfferServices _jobOfferServices;

        public JobOfferController(IJobOfferRepository jobOfferRepository, IJobOfferServices jobOfferServices)
        {
            _jobOfferRepository = jobOfferRepository;
            _jobOfferServices = jobOfferServices;
        }

        [HttpGet]
        public async Task<IEnumerable<JobOffer>> GetOffers()
        {
            return await _jobOfferRepository.GetJobOffers();
        }

        [HttpGet("{id}", Name = "JobOfferById")]
        public async Task<IActionResult> JobOfferById(int id)
        {
            try
            {
                var jobOffer = await _jobOfferRepository.GetJobOffer(id);
                if (jobOffer == null)
                    return NotFound();
                return Ok(jobOffer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<JobOffer>> CreateJob(JobOfferForCreationDto jobOffer)
        {
            try
            {
                var createdJobOffer = await _jobOfferServices.CreateJobOffer(jobOffer);
                return CreatedAtRoute("JobOfferById", new { id = createdJobOffer.Id }, createdJobOffer);
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateJobOffer(int id, JobOfferForUpdateDto jobOffer)
        {
            try
            {
                var dbJobOffer = await _jobOfferRepository.GetJobOffer(id);
                if (dbJobOffer == null)
                    return NotFound();
                await _jobOfferRepository.UpdateJobOffer(id, jobOffer);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            try
            {
                var dbJobOffer = await _jobOfferRepository.GetJobOffer(id);
                if (dbJobOffer == null)
                    return NotFound();
                await _jobOfferRepository.DeleteJobOffer(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                //log error
                return StatusCode(500, ex.Message);
            }
        }
    }
}
