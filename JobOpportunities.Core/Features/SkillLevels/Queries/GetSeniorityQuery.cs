using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Queries;

public class GetSeniorityQuery : IRequest<GetSeniorityResponse>
{
    public Guid SeniorityId { get; set; }
}

public class GetSkillLevelQueryHandler : IRequestHandler<GetSeniorityQuery, GetSeniorityResponse>
{
    private readonly IReadRepository<Seniority> _seniorityRepository;
    private readonly IMapper _mapper;

    public GetSkillLevelQueryHandler(IReadRepository<Seniority> seniorityRepository, IMapper mapper)
    {
        _seniorityRepository = seniorityRepository;
        _mapper = mapper;
    }
    public async Task<GetSeniorityResponse> Handle(GetSeniorityQuery request, CancellationToken cancellationToken)
    {
        var skillLevel = await _seniorityRepository.GetByIdAsync(request.SeniorityId);

        if (skillLevel is null)
            throw new NotFoundException();

        return _mapper.Map<GetSeniorityResponse>(skillLevel);
    }
}