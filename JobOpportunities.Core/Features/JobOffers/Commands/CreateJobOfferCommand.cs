using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
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
        public IEnumerable<SkillDto> RequiredSkills { get; set; }
        public Guid CompanyId { get; set; }

        public record SkillDto
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }

    public class CreateJobOfferCommandHandler : IRequestHandler<CreateJobOfferCommand, GetJobOfferResponse>
    {
        private readonly IGenericRepository<JobOffer> _jobOfferRepository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISkillRepository _skillRepository;

        public CreateJobOfferCommandHandler(IGenericRepository<JobOffer> jobOfferRepository, IMapper mapper, ICurrentUserService currentUserService, ISkillRepository skillRepository)
        {
            _jobOfferRepository = jobOfferRepository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _skillRepository = skillRepository;
        }
        public async Task<GetJobOfferResponse> Handle(CreateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var newJobOffer = _mapper.Map<JobOffer>(request);
            newJobOffer.CompanyId = new Guid(_currentUserService.User.Id);

            var skills = await _skillRepository.FindAllByConditionWithRelatedAsync(s => request.RequiredSkills.Select(x => x.Id).ToList().Contains(s.Id.ToString()));

            newJobOffer.RequiredSkills = skills;

            _jobOfferRepository.Add(newJobOffer);

            try
            {
                await _jobOfferRepository.SaveAsync(cancellationToken);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException.Message.Contains("FOREIGN KEY"))
                    throw new FKNotFoundException(typeof(CompanyAgent).Name, request.CompanyId);
                throw ex;
            }

            return _mapper.Map<GetJobOfferResponse>(newJobOffer);
        }
    }
}
