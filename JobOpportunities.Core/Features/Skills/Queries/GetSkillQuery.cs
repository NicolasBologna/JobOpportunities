using AutoMapper;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.Skills.Queries
{
    public class GetSkillQuery : IRequest<GetSkillResponse>
    {
        internal Guid SkillId { get; set; }
    }

    public class GetSkillQueryHandler : IRequestHandler<GetSkillQuery, GetSkillResponse>
    {
        private readonly IReadRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillQueryHandler(IReadRepository<Skill> skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<GetSkillResponse> Handle(GetSkillQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetByIdAsync(request.SkillId);

            return _mapper.Map<GetSkillResponse>(skills);

        }
    }
}
