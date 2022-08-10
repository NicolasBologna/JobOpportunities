using FluentValidation;
using JobOpportunities.Core.Features.JobOffers.Commands;

namespace JobOpportunities.Core.Features.JobOffers.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateJobOfferCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(r => r.Id).NotEmpty();
            RuleFor(r => r.Title).NotEmpty();
            RuleFor(r => r.ValidUntil).NotEmpty().GreaterThanOrEqualTo(DateTime.Now); ;
            RuleFor(r => r.CompanyId).NotEmpty();
            RuleFor(r => r.Description).NotNull().Length(0, 400);
        }
    }
}
