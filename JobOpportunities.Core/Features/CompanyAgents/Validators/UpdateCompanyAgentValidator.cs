using FluentValidation;
using JobOpportunities.Core.Features.CompanyAgents.Commands;
using JobOpportunities.Domain;

namespace JobOpportunities.Core.Features.CompanyAgents.Validators
{
    public class UpdateCompanyAgentValidator : AbstractValidator<UpdateCompanyAgentCommand>
    {
        public UpdateCompanyAgentValidator()
        {
        }
    }
}
