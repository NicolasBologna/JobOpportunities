using FluentValidation;
using JobOpportunities.Core.Features.SkillLevels.Commands;

namespace JobOpportunities.Core.Features.SkillLevels.Validators
{
    public class CreateSkillLevelValidator : AbstractValidator<CreateSkillLevelCommand>
    {
        public CreateSkillLevelValidator()
        {
            RuleFor(s => s.Name).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(s => s.Description).MaximumLength(500);
        }
    }
}
