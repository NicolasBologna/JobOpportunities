using AutoMapper;
using JobOpportunities.Core.Features.Skills.Commands;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillCommand, Skill>();
            CreateMap<Skill, GetSkillResponse>();
            CreateMap<Skill, GetSkillsResponse>();
        }

    }
}
