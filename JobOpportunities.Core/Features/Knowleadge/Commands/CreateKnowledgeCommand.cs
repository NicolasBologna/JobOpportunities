using AutoMapper;
using JobOpportunities.Core.Common.Attributes;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using MediatR;

namespace JobOpportunities.Core.Features.KnowledgeFeatures.Commands
{
    [AuditLog]
    public class CreateKnowledgeCommand : IRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }

    public class CreateKnowledgeCommandHandler : IRequestHandler<CreateKnowledgeCommand>
    {
        private readonly IGenericRepository<Knowledge> _knowledgeRepository;
        private readonly IMapper _mapper;

        public CreateKnowledgeCommandHandler(IGenericRepository<Knowledge> knowledgeRepository, IMapper mapper)
        {
            _knowledgeRepository = knowledgeRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(CreateKnowledgeCommand request, CancellationToken cancellationToken)
        {
            var newKnowledge = _mapper.Map<Knowledge>(request);

            _knowledgeRepository.Add(newKnowledge);
            if (!await _knowledgeRepository.SaveAsync())
            {
                //
            }

            return Unit.Value;
        }
    }
}
