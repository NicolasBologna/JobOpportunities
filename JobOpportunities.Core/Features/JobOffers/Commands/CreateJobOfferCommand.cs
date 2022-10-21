using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    [AuditLog]
    public class CreateJobOfferCommand : IRequest<GetJobOfferResponse>
    {
        public string Title { get; set; } = default!;
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public IEnumerable<string> RequiredSkillsIds { get; set; }
        public Guid CompanyId { get; set; }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, GetJobOfferResponse>
    {
        private readonly IGenericRepository<JobOffer> _jobOfferRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;

        public CreateJobOfferCommandHandler(IGenericRepository<JobOffer> jobOfferRepository, IMapper mapper, ICurrentUserService currentUserService)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
        }
        public async Task<GetJobOfferResponse> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var newJobOffer = _mapper.Map<JobOffer>(request);
            newJobOffer.CompanyId = new Guid(_currentUserService.User.Id);

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

            return _mapper.Map<GetJobOfferResponse>(newJobOffer);
        }
    }
}
