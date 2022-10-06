using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace JobOpportunities.Core.Features.CompanyAgents.Commands
{
    public class CreateCompanyAgentCommand : IRequest<Guid>
    {
        public string Cuit { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
    }

    public class CreateCompanyAgentCommandHandler : IRequestHandler<CreateCompanyAgentCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<CompanyAgent> _userManager;

        public CreateCompanyAgentCommandHandler(IMapper mapper, UserManager<CompanyAgent> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Guid> Handle(CreateCompanyAgentCommand request, CancellationToken cancellationToken)
        {
            var newObject = _mapper.Map<CompanyAgent>(request);

            var result = new IdentityResult();


            result = await _userManager.CreateAsync(newObject, request.Password);


            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newObject, "CompanyAgent");
                return newObject.Id;
            }
            throw new IdentityErrorException(result.Errors);
        }
    }
}
