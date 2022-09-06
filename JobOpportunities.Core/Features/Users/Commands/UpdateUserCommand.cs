using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOpportunities.Core.Features.Users.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Id { get; set; } = null!;
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id);
            if (user is null)
                throw new NotFoundException("User", request.Id);

            _mapper.Map(request, user);
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new Unit();
            }

            throw new IdentityErrorException(result.Errors);
        }
    }
}
