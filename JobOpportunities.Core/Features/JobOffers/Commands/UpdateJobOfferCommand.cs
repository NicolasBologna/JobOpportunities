using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    [AuditLog]
    public class UpdateJobOfferCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand>
    {
        private readonly IGenericRepository<JobOffer> _repository;
        private readonly IMapper _mapper;

        public UpdateJobOfferCommandHandler(IGenericRepository<JobOffer> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOffer = await _repository.GetByIdAsync(request.Id);

            if (jobOffer is null)
            {
                throw new NotFoundException();
            }

            _mapper.Map(request, jobOffer);

            await _repository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
