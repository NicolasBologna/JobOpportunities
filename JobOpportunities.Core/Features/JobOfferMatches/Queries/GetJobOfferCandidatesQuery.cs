using AutoMapper;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOfferMatches.Models;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.SpecificRepositories;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.JobOfferMatches.Queries
{
    public class GetJobOfferCandidatesQuery : IRequest<IEnumerable<GetJobOfferCandidatesResponse>>
    {
        public Guid JobOfferId { get; set; }
    }

    public class GetJobOfferCandidatesQueryHandler : IRequestHandler<GetJobOfferCandidatesQuery, IEnumerable<GetJobOfferCandidatesResponse>>
    {
        private readonly ICandidatesRepository _candidateRepository;
        private readonly IMapper _mapper;
        private readonly IJobOfferRepository _jobOfferRepository;

        public GetJobOfferCandidatesQueryHandler(ICandidatesRepository candidateRepository, IMapper mapper, IReadRepository<Skill> skillRepository, IJobOfferRepository jobOfferRepository)
        {
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _jobOfferRepository = jobOfferRepository;
        }
        public async Task<IEnumerable<GetJobOfferCandidatesResponse>> Handle(GetJobOfferCandidatesQuery request, CancellationToken cancellationToken)
        {
            var jobOfferSkills = await _jobOfferRepository.GetAllRequiredSkills(request.JobOfferId);

            if (jobOfferSkills is null)
                throw new NotFoundException();

            IEnumerable<Guid>? requiredSkillsIds = jobOfferSkills.Select(r => r.Id);

            var candidates = await _candidateRepository.GetallWithSkills();

            var filteredCandidates = candidates.Where(c => !requiredSkillsIds.Except(c.Skills.Select(s => s.Id)).Any());

            return _mapper.Map<IEnumerable<GetJobOfferCandidatesResponse>>(filteredCandidates);
        }
    }
}
