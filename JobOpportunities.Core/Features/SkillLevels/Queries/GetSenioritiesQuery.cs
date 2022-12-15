using AutoMapper;
using JobOpportunities.Core.Features.SkillLevels.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.SkillLevels.Queries;

public class GetSenioritiesQuery : IRequest<IEnumerable<GetSenioritiesResponse>>
{
}

public class GetSenioritysQueryHandler : IRequestHandler<GetSenioritiesQuery, IEnumerable<GetSenioritiesResponse>>
{
    private readonly IReadRepository<Seniority> _seniorityRepository;
    private readonly IMapper _mapper;

    public GetSenioritysQueryHandler(IReadRepository<Seniority> seniorityRepository, IMapper mapper)
    {
        _seniorityRepository = seniorityRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetSenioritiesResponse>> Handle(GetSenioritiesQuery request, CancellationToken cancellationToken)
    {
        var skillLevels = await _seniorityRepository.GetAllAsync();

        return _mapper.Map<List<GetSenioritiesResponse>>(skillLevels);
    }
}