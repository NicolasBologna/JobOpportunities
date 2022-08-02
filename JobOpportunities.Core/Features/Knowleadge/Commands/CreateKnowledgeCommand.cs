using AutoMapper;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using MediatR;

namespace JobOpportunities.Core.Features.KnowledgeFeatures.Commands
{
    public class CreateKnowledgeCommand : IRequest
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }

    public class CreateKnowledgeCommandHandler : IRequestHandler<CreateKnowledgeCommand>
    {
        private readonly IRepository<Knowledge> _knowledgeRepository;
        private readonly IMapper _mapper;

        public CreateKnowledgeCommandHandler(IRepository<Knowledge> knowledgeRepository, IMapper mapper)
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
