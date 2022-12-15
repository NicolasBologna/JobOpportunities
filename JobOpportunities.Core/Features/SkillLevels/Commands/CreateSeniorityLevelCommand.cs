using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Commands
{
    [AuditLog]
    public class CreateSeniorityLevelCommand : IRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSkillLevelCommandHandler : IRequestHandler<CreateSeniorityLevelCommand>
    {
        private readonly IGenericRepository<Seniority> _seniorityRepository;
        private readonly IMapper _mapper;

        public CreateSkillLevelCommandHandler(IGenericRepository<Seniority> seniorityRepository, IMapper mapper)
        {
            _seniorityRepository = seniorityRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSeniorityLevelCommand request, CancellationToken cancellationToken)
        {
            var newSkillLevel = _mapper.Map<Seniority>(request);

            _seniorityRepository.Add(newSkillLevel);
            if (!await _seniorityRepository.SaveAsync())
            {
                //
            }

            return Unit.Value;
        }
    }
}
