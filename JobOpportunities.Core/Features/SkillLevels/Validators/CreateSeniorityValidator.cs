using FluentValidation;
using JobOpportunities.Core.Features.SkillLevels.Commands;

namespace JobOpportunities.Core.Features.SkillLevels.Validators
{
    public class CreateSeniorityValidator : AbstractValidator<CreateSeniorityLevelCommand>
    {
        public CreateSeniorityValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(s => s.Description).MaximumLength(500);
        }
    }
}
