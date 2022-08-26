using EndavaCareers.API.Dto;
using EndavaCareers.API.Entities;

namespace EndavaCareers.API.Contracts
{
    public interface IJobOfferRepository
    {
        public Task<IEnumerable<JobOffer>> GetJobOffers();
        public Task<JobOffer> GetJobOffer(int id);
        public Task<JobOffer> CreateJobOffer(JobOfferForCreationDto jobOffer);
        public Task UpdateJobOffer(int id, JobOfferForUpdateDto jobOffer);
        public Task DeleteJobOffer(int id);
    }
}
