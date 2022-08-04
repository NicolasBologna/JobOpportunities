using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Queries;

public class GetJobOfferQuery : IRequest<GetJobOfferResponse>
{
    public Guid JobOfferId { get; set; }
}

public class GetJobOfferQueryHandler : IRequestHandler<GetJobOfferQuery, GetJobOfferResponse>
{
    private readonly IReadRepository<JobOffer> _jobOfferRepository;
    private readonly IMapper _mapper;

    public GetJobOfferQueryHandler(IReadRepository<JobOffer> jobOfferRepository, IMapper mapper)
    {
        _jobOfferRepository = jobOfferRepository;
        _mapper = mapper;
    }
    public async Task<GetJobOfferResponse> Handle(GetJobOfferQuery request, CancellationToken cancellationToken)
    {
        var jobOffer = await _jobOfferRepository.GetByIdAsync(request.JobOfferId);

        if (jobOffer is null)
        {
            throw new NotFoundException(nameof(jobOffer), request.JobOfferId);
        }

        return _mapper.Map<GetJobOfferResponse>(jobOffer);
    }
}