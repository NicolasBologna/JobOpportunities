using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Commands
{
    [AuditLog]
    public class CreateSkillLevelCommand : IRequest
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSkillLevelCommandHandler : IRequestHandler<CreateSkillLevelCommand>
    {
        private readonly IGenericRepository<SkillLevel> _skillLevelRepository;
        private readonly IMapper _mapper;

        public CreateSkillLevelCommandHandler(IGenericRepository<SkillLevel> skillLevelRepository, IMapper mapper)
        {
            _skillLevelRepository = skillLevelRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSkillLevelCommand request, CancellationToken cancellationToken)
        {
            var newSkillLevel = _mapper.Map<SkillLevel>(request);

            _skillLevelRepository.Add(newSkillLevel);
            if (!await _skillLevelRepository.SaveAsync())
            {
                //
            }

            return Unit.Value;
        }
    }
}
