using AutoMapper;
using JobOpportunities.Core.Features.SkillLevels.Commands;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class SkillLevelProfile : Profile
    {
        public SkillLevelProfile()
        {
            CreateMap<SkillLevel, GetSkillLevelsResponse>();
            CreateMap<SkillLevel, GetSkillLevelResponse>();
            CreateMap<CreateSkillLevelCommand, SkillLevel>();
        }
    }
}
