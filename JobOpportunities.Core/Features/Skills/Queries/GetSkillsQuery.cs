using AutoMapper;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.Skills.Queries
{
    public class GetSkillsQuery : IRequest<GetSkillsResponse>
    {
    }

    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, GetSkillsResponse>
    {
        private readonly IReadRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillsQueryHandler(IReadRepository<Skill> skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<GetSkillsResponse> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            return _mapper.Map<GetSkillsResponse>(skills);
        }
    }
}
