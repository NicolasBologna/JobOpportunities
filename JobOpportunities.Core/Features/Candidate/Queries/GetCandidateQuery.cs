using JobOpportunities.Core.Features.Candidates.Models;
using MediatR;

namespace JobOpportunities.Core.Features.Candidates.Queries;

public class GetCandidateQuery : IRequest<GetCandidateResponse>
{
    public Guid CandidateId { get; set; }
}

//public class GetCandidateQueryHandler : IRequestHandler<GetCandidateQuery, GetCandidateResponse>
//{
//    private readonly IReadRepository<Candidate> _candidateRepository;
//    private readonly IMapper _mapper;

//    public GetCandidateQueryHandler(IReadRepository<Candidate> candidateRepository, IMapper mapper)
//    {
//        _candidateRepository = candidateRepository;
//        _mapper = mapper;
//    }
//    public async Task<GetCandidateResponse> Handle(GetCandidateQuery request, CancellationToken cancellationToken)
//    {
//        var candidate = await _candidateRepository.GetByIdAsync(request.CandidateId);

//        return _mapper.Map<GetCandidateResponse>(candidate);
//    }
//}