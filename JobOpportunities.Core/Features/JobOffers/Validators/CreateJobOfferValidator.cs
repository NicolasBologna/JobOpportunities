using FluentValidation;
using JobOpportunities.Core.Features.JobOffers.Commands;

namespace JobOpportunities.Core.Features.JobOffers.Validators
{
    public class CreateJobOfferValidator : AbstractValidator<CreateJobOfferCommand>
    {
        public CreateJobOfferValidator()
        {
            RuleFor(r => r.Title).NotNull();
            RuleFor(r => r.Description).NotNull().Length(0, 400);
            RuleFor(r => r.ValidUntil).NotNull().GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}
