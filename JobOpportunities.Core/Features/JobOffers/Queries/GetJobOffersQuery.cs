using AutoMapper;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Queries;

public class GetJobOffersQuery : IRequest<IEnumerable<GetJobOffersResponse>>
{
}

public class GetJobOffersQueryHandler : IRequestHandler<GetJobOffersQuery, IEnumerable<GetJobOffersResponse>>
{
    private readonly IReadRepository<JobOffer> _jobOfferRepository;
    private readonly IMapper _mapper;

    public GetJobOffersQueryHandler(IReadRepository<JobOffer> jobOfferRepository, IMapper mapper)
    {
        _jobOfferRepository = jobOfferRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetJobOffersResponse>> Handle(GetJobOffersQuery request, CancellationToken cancellationToken)
    {
        var jobOffers = await _jobOfferRepository.GetAllAsync();

        return _mapper.Map<List<GetJobOffersResponse>>(jobOffers);
    }
}