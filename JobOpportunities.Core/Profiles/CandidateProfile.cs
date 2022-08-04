using AutoMapper;
using JobOpportunities.Core.Features.JobOfferMatches.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, GetJobOfferCandidatesResponse>();
        }
    }
}
