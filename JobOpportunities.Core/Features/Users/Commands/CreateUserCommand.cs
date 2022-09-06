using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.Users.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var newUser = _mapper.Map<ApplicationUser>(request);

            var result = await _userManager.CreateAsync(newUser, request.Password);
            if (result.Succeeded)
            {
                return newUser.Id;
            }
            throw new IdentityErrorException(result.Errors);
        }
    }
}
