using AutoMapper;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.Skills.Commands
{
    public class CreateSkillCommand : IRequest
    {
        public Guid KnowleadgeId { get; set; }
        public Guid SkillLevelId { get; set; }
    }

    public class CreateSkillCommandHandler : IRequestHandler<CreateSkillCommand>
    {
        private readonly IGenericRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;

        public CreateSkillCommandHandler(IGenericRepository<Skill> skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
        {
            var newJobOffer = _mapper.Map<Skill>(request);

            _skillRepository.Add(newJobOffer);
            if (!await _skillRepository.SaveAsync())
            {
                //
            }

            return Unit.Value;
        }
    }
}
