using AutoMapper;
using FluentAssertions;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Core.Features.JobOffers.Queries;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using Moq;

namespace JobOpportunities.Core.UnitTests
{
    public class GetJobOffersQueryHandlerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task ShouldReturnAllJobOffers()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IReadRepository<JobOffer>>();

            mockRepository.Setup(x => x.GetAllAsync()).ReturnsAsync(new List<JobOffer> { new JobOffer(), new JobOffer() });
            mockMapper.Setup(x => x.Map<List<GetJobOffersResponse>>(It.IsAny<List<JobOffer>>())).Returns(new List<GetJobOffersResponse> { new GetJobOffersResponse(), new GetJobOffersResponse() });

            var getJobOffersQueryHandler = new GetJobOffersQueryHandler(mockRepository.Object, mockMapper.Object);

            var jobOffers = await getJobOffersQueryHandler.Handle(new GetJobOffersQuery(), new CancellationToken());

            jobOffers.Should().HaveCount(2);
        }
    }
}