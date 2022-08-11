using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    [AuditLog]
    public class CreateJobOfferCommand : IRequest
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand>
    {
        private readonly IGenericRepository<JobOffer> _jobOfferRepository;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Company> _companyRepository;

        public CreateJobOfferCommandHandler(IGenericRepository<JobOffer> jobOfferRepository, IMapper mapper, IGenericRepository<Company> companyRepository)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
            _companyRepository = companyRepository;
        }
        public async Task<Unit> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var newJobOffer = _mapper.Map<JobOffer>(request);

            if (!await _companyRepository.ItemExists(request.CompanyId))
                throw new NotFoundException();

            _jobOfferRepository.Add(newJobOffer);
            if (!await _jobOfferRepository.SaveAsync(cancellationToken))
            {
                //What happen if Company Id doesn't exists
            }

            return Unit.Value;
        }
    }
}
