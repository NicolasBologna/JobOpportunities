using AutoMapper;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Queries;

public class GetSkillLevelsQuery : IRequest<IEnumerable<GetSkillLevelsResponse>>
{
}

public class GetSkillLevelsQueryHandler : IRequestHandler<GetSkillLevelsQuery, IEnumerable<GetSkillLevelsResponse>>
{
    private readonly IReadRepository<SkillLevel> _skillLevelRepository;
    private readonly IMapper _mapper;

    public GetSkillLevelsQueryHandler(IReadRepository<SkillLevel> skillLevelRepository, IMapper mapper)
    {
        _skillLevelRepository = skillLevelRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetSkillLevelsResponse>> Handle(GetSkillLevelsQuery request, CancellationToken cancellationToken)
    {
        var skillLevels = await _skillLevelRepository.GetAllAsync();

        return _mapper.Map<List<GetSkillLevelsResponse>>(skillLevels);
    }
}