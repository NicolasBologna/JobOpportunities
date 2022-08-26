using EndavaCareers.API.Contracts;
using EndavaCareers.API.Dto;
using EndavaCareers.API.Entities;
using EndavaCareers.API.Integrations;

namespace EndavaCareers.API.Services
{
    public class JobOfferServices : IJobOfferServices
    {
        private readonly IJobOfferRepository _jobOfferRepository;
        private readonly ISender _sender;

        public JobOfferServices(IJobOfferRepository jobOfferRepository, ISender sender)
        {
            _jobOfferRepository = jobOfferRepository;
            _sender = sender;
        }
        public async Task<JobOffer> CreateJobOffer(JobOfferForCreationDto jobOffer)
        {
            var newJobOffer = await _jobOfferRepository.CreateJobOffer(jobOffer);
            _sender.CreateEntity<JobOffer>(newJobOffer);
            return newJobOffer;
        }
    }
}
