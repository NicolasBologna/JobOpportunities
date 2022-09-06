using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
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

        public CreateJobOfferCommandHandler(IGenericRepository<JobOffer> jobOfferRepository, IMapper mapper)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
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
                    throw new FKNotFoundException(typeof(CompanyAgent).Name, request.CompanyId);
            }

            return Unit.Value;
        }
    }
}
