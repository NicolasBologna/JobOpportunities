using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using MediatR;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    //[AuditLog]
    public class DeleteJobOfferCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteJobOfferCommandHandler : IRequestHandler<DeleteJobOfferCommand>
    {
        private readonly IJobOfferRepository _repository;

        public DeleteJobOfferCommandHandler(IJobOfferRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOffer = await _repository.FindByConditionAsync(x => x.Id == request.Id);

            if (jobOffer is null)
            {
                throw new NotFoundException();
            }

            await _repository.Remove(jobOffer);

            await _repository.SaveAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
