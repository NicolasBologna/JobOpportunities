using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Abstractions;
using JobOpportunities.Domain;
using MediatR;
using static JobOpportunities.Core.Features.JobOffers.Commands.CreateJobOfferCommand;

namespace JobOpportunities.Core.Features.JobOffers.Commands
{
    [AuditLog]
    public class UpdateJobOfferCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime ValidUntil { get; set; }
        public IEnumerable<SkillDto> RequiredSkills { get; set; }
    }

    public class UpdateJobOfferCommandHandler : IRequestHandler<UpdateJobOfferCommand>
    {
        private readonly IJobOfferRepository _repository;
        private readonly IMapper _mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISkillRepository _skillRepository;

        public UpdateJobOfferCommandHandler(IJobOfferRepository repository, IMapper mapper, ICurrentUserService currentUserService, ISkillRepository skillRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _currentUserService = currentUserService;
            _skillRepository = skillRepository;
        }

        public async Task<Unit> Handle(UpdateJobOfferCommand request, CancellationToken cancellationToken)
        {
            var jobOffer = await _repository.GetWithRequiredSkills(request.Id);

            if (jobOffer is null)
            {
                throw new NotFoundException();
            }

            _mapper.Map(request, jobOffer);
            jobOffer.CompanyId = new Guid(_currentUserService.User.Id);
            var skills = await _skillRepository.FindAllByConditionWithRelatedAsync(s => request.RequiredSkills.Select(x => x.Id).ToList().Contains(s.Id.ToString()));
            jobOffer.RequiredSkills = skills;


            var isCompleted = await _repository.SaveAsync(cancellationToken);
            if (!isCompleted)
            {
                throw new Exception(); //TODO: excepciones de bases de datos.wse3w4e330e3€
            }

            return Unit.Value;
        }
    }
}
