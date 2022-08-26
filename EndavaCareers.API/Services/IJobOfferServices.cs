using EndavaCareers.API.Dto;
using EndavaCareers.API.Entities;

namespace EndavaCareers.API.Services
{
    public interface IJobOfferServices
    {
        Task<JobOffer> CreateJobOffer(JobOfferForCreationDto jobOffer);
    }
}