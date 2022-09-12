using AutoMapper;
using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Core.Features.CompanyAgents.Models;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;

namespace JobOpportunities.Core.Features.CompanyAgents.Profiles
{
    public class CompanyAgentProfile : Profile
    {
        public CompanyAgentProfile()
        {
            CreateMap<CompanyAgent, GetCompanyAgentResponse>();
            CreateMap<CompanyAgent, GetCompanyAgentsResponse>();
            CreateMap<CreateCompanyAgentCommand, CompanyAgent>();
            CreateMap<UpdateCompanyAgentCommand, CompanyAgent>();
        }
    }
}
