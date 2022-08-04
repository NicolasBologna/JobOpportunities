using FluentValidation;
using JobOpportunities.Core.Features.JobOfferMatches.Queries;

namespace JobOpportunities.Core.Features.JobOfferMatches.Validators
{
    public class GetJobOfferCandidatesValidator : AbstractValidator<GetJobOfferCandidatesQuery>
    {
        public GetJobOfferCandidatesValidator()
        {
            RuleFor(r => r.JobOfferId).NotEmpty().Must(id => !id.Equals(new Guid("00000000-0000-0000-0000-000000000000")));
        }
    }
}
