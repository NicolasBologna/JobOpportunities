using AutoMapper;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Core.Features.KnowledgeFeatures.Models;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.KnowledgeFeatures.Queries;

public class GetKnowledgeQuery : IRequest<GetKnowledgeResponse>
{
    public Guid KnowledgeId { get; set; }
}

public class GetKnowledgeQueryHandler : IRequestHandler<GetKnowledgeQuery, GetKnowledgeResponse>
{
    private readonly IReadRepository<Knowledge> _knowledgeRepository;
    private readonly IMapper _mapper;

    public GetKnowledgeQueryHandler(IReadRepository<Knowledge> knowledgeRepository, IMapper mapper)
    {
        _knowledgeRepository = knowledgeRepository;
        _mapper = mapper;
    }
    public async Task<GetKnowledgeResponse> Handle(GetKnowledgeQuery request, CancellationToken cancellationToken)
    {
        var knowledge = await _knowledgeRepository.GetByIdAsync(request.KnowledgeId);

        return _mapper.Map<GetKnowledgeResponse>(knowledge);
    }
}