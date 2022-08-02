using AutoMapper;
using JobOpportunities.Core.Features.KnowledgeFeatures.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.KnowledgeFeatures.Queries;

public class GetAllKnowledgeQuery : IRequest<IEnumerable<GetAllKnowledgeResponse>>
{
}

public class GetAllKnowledgeQueryHandler : IRequestHandler<GetAllKnowledgeQuery, IEnumerable<GetAllKnowledgeResponse>>
{
    private readonly IReadRepository<Knowledge> _knowledgeRepository;
    private readonly IMapper _mapper;

    public GetAllKnowledgeQueryHandler(IReadRepository<Knowledge> knowledgeRepository, IMapper mapper)
    {
        _knowledgeRepository = knowledgeRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllKnowledgeResponse>> Handle(GetAllKnowledgeQuery request, CancellationToken cancellationToken)
    {
        var knowledge = await _knowledgeRepository.GetAllAsync();

        return _mapper.Map<List<GetAllKnowledgeResponse>>(knowledge);
    }
}