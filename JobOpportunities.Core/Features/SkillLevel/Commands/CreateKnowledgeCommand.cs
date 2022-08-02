using AutoMapper;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Commands
{
    public class CreateSkillLevelCommand : IRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }

    public class CreateSkillLevelCommandHandler : IRequestHandler<CreateSkillLevelCommand>
    {
        private readonly IRepository<SkillLevel> _skillLevelRepository;
        private readonly IMapper _mapper;

        public CreateSkillLevelCommandHandler(IRepository<SkillLevel> skillLevelRepository, IMapper mapper)
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
