using AutoMapper;
using JobOpportunities.Core.Features.KnowledgeFeatures.Commands;
using JobOpportunities.Core.Features.KnowledgeFeatures.Models;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Profiles
{
    public class KnowledgeProfile : Profile
    {
        public KnowledgeProfile()
        {
            CreateMap<Knowledge, GetKnowledgeResponse>();
            CreateMap<Knowledge, GetAllKnowledgeResponse>();
            CreateMap<CreateKnowledgeCommand, Knowledge>();
        }
    }
}
