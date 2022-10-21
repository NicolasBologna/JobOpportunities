using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class JobOfferProfile : Profile
    {
        public JobOfferProfile()
        {
            CreateMap<JobOffer, GetJobOfferResponse>();
            CreateMap<JobOffer, GetJobOffersResponse>();
            CreateMap<CreateJobOfferCommand, JobOffer>();
            CreateMap<UpdateJobOfferCommand, JobOffer>();
            CreateMap<JobOffer, GetCompanyAgentResponse.CompanyJobOffer>();
            CreateMap<JobOffer, GetCompanyAgentJobOffersResponse>();
        }
    }
}
