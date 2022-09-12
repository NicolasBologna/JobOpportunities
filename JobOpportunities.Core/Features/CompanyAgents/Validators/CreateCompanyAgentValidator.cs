using FluentValidation;
using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Features.CompanyAgents.Validators
{
    public class CreateCompanyAgentValidator : AbstractValidator<CreateCompanyAgentCommand>
    {
        public CreateCompanyAgentValidator()
        {
        }
    }
}
