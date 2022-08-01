using AutoMapper;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    public class CreateJobOfferCommand : IRequest
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand>
    {
        private readonly IRepository<JobOffer> _jobOfferRepository;
        private readonly IMapper _mapper;

        public CreateJobOfferCommandHandler(IRepository<JobOffer> jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var newJobOffer = _mapper.Map<JobOffer>(request);

            _jobOfferRepository.Add(newJobOffer);
            if (!await _jobOfferRepository.SaveAsync())
            {
                //
            }

            return Unit.Value;
        }
    }
}
