using AutoMapper;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Queries;

public class GetSkillLevelQuery : IRequest<GetSkillLevelResponse>
{
    public Guid SkillLevelId { get; set; }
}

public class GetSkillLevelQueryHandler : IRequestHandler<GetSkillLevelQuery, GetSkillLevelResponse>
{
    private readonly IReadRepository<SkillLevel> _skillLevelRepository;
    private readonly IMapper _mapper;

    public GetSkillLevelQueryHandler(IReadRepository<SkillLevel> skillLevelRepository, IMapper mapper)
    {
        _skillLevelRepository = skillLevelRepository;
        _mapper = mapper;
    }
    public async Task<GetSkillLevelResponse> Handle(GetSkillLevelQuery request, CancellationToken cancellationToken)
    {
        var skillLevel = await _skillLevelRepository.GetByIdAsync(request.SkillLevelId);

        return _mapper.Map<GetSkillLevelResponse>(skillLevel);
    }
}