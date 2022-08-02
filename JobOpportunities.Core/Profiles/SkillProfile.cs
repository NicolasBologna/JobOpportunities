using AutoMapper;
using JobOpportunities.Core.Features.Skills.Commands;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class SkillProfile : Profile
    {
        public SkillProfile()
        {
            CreateMap<CreateSkillCommand, Skill>();
        }

    }
}
