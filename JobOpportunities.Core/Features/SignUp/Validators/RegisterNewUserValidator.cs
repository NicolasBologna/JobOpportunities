using FluentValidation;
using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Core.Features.SignUp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.SignUp.Validators
{
    public class RegisterNewUserValidator : AbstractValidator<RegisterNewUserCommand>
    {
        public RegisterNewUserValidator()
        {
            RuleFor(r => r.Email).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.ConfirmPassword).Equal(r => r.Password);
        }
    }
}
