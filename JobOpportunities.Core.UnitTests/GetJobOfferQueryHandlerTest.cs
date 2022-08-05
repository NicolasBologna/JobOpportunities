using AutoMapper;
using FluentAssertions;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOffers.Models;
using JobOpportunities.Core.Features.JobOffers.Queries;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using Moq;

namespace JobOpportunities.Core.UnitTests
{
    public class GetJobOfferQueryHandlerTest
    {
        private JobOffer jobOffer;
        private GetJobOfferResponse getJobOfferResponse;

        [SetUp]
        public void Setup()
        {
            this.jobOffer = new JobOffer
            {
                Id = new Guid("38656340-8ea7-427c-8587-3e6c6641cb62"),
                CreationDate = DateTime.Now,
                Title = "test offer",
                ValidUntil = DateTime.Now.AddDays(20),
                Description = "test Description",
            };

            this.getJobOfferResponse = new GetJobOfferResponse
            {
                Id = new Guid("38656340-8ea7-427c-8587-3e6c6641cb62"),
                Title = "test offer",
                ValidUntil = DateTime.Now.AddDays(20),
                Description = "test Description",
            };
        }

        [Test]
        public async Task ShouldReturnOneJobOffer()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IReadRepository<JobOffer>>();

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(new JobOffer());
            mockMapper.Setup(x => x.Map<GetJobOfferResponse>(It.IsAny<JobOffer>())).Returns(this.getJobOfferResponse);

            var getJobOffersQueryHandler = new GetJobOfferQueryHandler(mockRepository.Object, mockMapper.Object);

            var query = new GetJobOfferQuery
            {
                JobOfferId = new Guid("38656340-8ea7-427c-8587-3e6c6641cb62")
            };

            var jobOffer = await getJobOffersQueryHandler.Handle(query, new CancellationToken());

            jobOffer.Should().NotBeNull();
            jobOffer.Id.Should().Be("38656340-8ea7-427c-8587-3e6c6641cb62");
        }

        [Test]
        public async Task ShouldThrowNotFoundJobOffer()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IReadRepository<JobOffer>>();

            mockRepository.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).Returns(Task.FromResult((JobOffer?)null));

            var getJobOffersQueryHandler = new GetJobOfferQueryHandler(mockRepository.Object, mockMapper.Object);

            var query = new GetJobOfferQuery
            {
                JobOfferId = new Guid("38656340-8ea7-427c-8587-3e6c6641cb62")
            };

            await getJobOffersQueryHandler.Invoking(y => y.Handle(query, new CancellationToken())).Should().ThrowAsync<NotFoundException>();
        }
    }
}