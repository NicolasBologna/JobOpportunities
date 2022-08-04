using AutoMapper;
using JobOpportunities.Core.Features.Skills.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.Skills.Queries
{
    public class GetSkillsQuery : IRequest<List<GetSkillsResponse>>
    {
    }

    public class GetSkillsQueryHandler : IRequestHandler<GetSkillsQuery, List<GetSkillsResponse>>
    {
        private readonly IReadRepository<Skill> _skillRepository;
        private readonly IMapper _mapper;

        public GetSkillsQueryHandler(IReadRepository<Skill> skillRepository, IMapper mapper)
        {
            _skillRepository = skillRepository;
            _mapper = mapper;
        }
        public async Task<List<GetSkillsResponse>> Handle(GetSkillsQuery request, CancellationToken cancellationToken)
        {
            var skills = await _skillRepository.GetAllAsync();

            return _mapper.Map<List<GetSkillsResponse>>(skills);
        }
    }
}
