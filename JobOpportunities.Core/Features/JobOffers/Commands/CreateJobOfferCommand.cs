using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

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

            _jobOfferRepository.Add(newJobOffer);

            try
            {
                await _jobOfferRepository.SaveAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("FOREIGN KEY"))
                    throw new FKNotFoundException(typeof(Company).Name, request.CompanyId);
            }

            return Unit.Value;
        }
    }
}
