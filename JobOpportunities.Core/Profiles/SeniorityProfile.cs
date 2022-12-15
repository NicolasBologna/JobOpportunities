using AutoMapper;
using JobOpportunities.Core.Features.SkillLevels.Commands;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class SeniorityProfile : Profile
    {
        public SeniorityProfile()
        {
            CreateMap<Seniority, GetSenioritiesResponse>();
            CreateMap<Seniority, GetSeniorityResponse>();
            CreateMap<CreateSeniorityLevelCommand, Seniority>();
        }
    }
}
