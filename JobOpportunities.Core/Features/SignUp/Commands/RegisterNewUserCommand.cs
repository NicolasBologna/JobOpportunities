using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.SignUp.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.SignUp.Commands
{
    [AuditLog]
    public class RegisterNewUserCommand : IRequest<RegisterNewUserResponse>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string UserType { get; set; }
    }

    public class RegisterNewUSerCommandHandler : IRequestHandler<RegisterNewUserCommand, RegisterNewUserResponse>
    {
        private readonly UserManager<ApplicationUser> _candidateManager;
        private readonly IMapper _mapper;

        public RegisterNewUSerCommandHandler(UserManager<ApplicationUser> candidateManager, IMapper mapper)
        {
            _candidateManager = candidateManager;
            _mapper = mapper;
        }
        public async Task<RegisterNewUserResponse> Handle(RegisterNewUserCommand userForRegistration, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(userForRegistration);
            var result = await _candidateManager.CreateAsync(user, userForRegistration.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description);

                return new RegisterNewUserResponse { Errors = errors, IsSuccessfulRegistration = false };
            }
            await _candidateManager.AddToRoleAsync(user, userForRegistration.UserType);
            return new RegisterNewUserResponse { IsSuccessfulRegistration = true };
        }
    }
}
