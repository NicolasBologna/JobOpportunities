using AutoMapper;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
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
        private readonly IRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;

        public CreateSkillCommandHandler(IRepository<Skill> skillRepository, IMapper mapper)
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
