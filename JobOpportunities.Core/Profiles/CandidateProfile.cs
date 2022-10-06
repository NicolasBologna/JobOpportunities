using AutoMapper;
using JobOpportunities.Core.Features.JobOfferMatches.Models;
using JobOpportunities.Core.Features.SignUp.Commands;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class CandidateProfile : Profile
    {
        public CandidateProfile()
        {
            CreateMap<Candidate, GetJobOfferCandidatesResponse>();
            CreateMap<RegisterNewUserCommand, Candidate>().ForMember(c => c.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
