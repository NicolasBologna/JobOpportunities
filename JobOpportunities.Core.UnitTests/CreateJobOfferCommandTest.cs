using AutoMapper;
using FluentAssertions;
using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using Moq;

namespace JobOpportunities.Core.UnitTests
{
    public class CreateJobOfferCommandTest
    {
        private JobOffer newJobOffer;
        private CreateJobOfferCommand createJobOfferCommand;

        [SetUp]
        public void Setup()
        {
            this.newJobOffer = new JobOffer
            {
                Id = new Guid("38656340-8ea7-427c-8587-3e6c6641cb62"),
                CreationDate = DateTime.Now,
                Title = "test offer",
                ValidUntil = DateTime.Now.AddDays(20),
                Description = "test Description",
            };

            this.createJobOfferCommand = new CreateJobOfferCommand
            {
                Title = "test offer",
                ValidUntil = DateTime.Now.AddDays(20),
                Description = "test Description",
            };
        }

        [Test]
        public async Task ShouldCreateANewJobOffer()
        {
            var mockMapper = new Mock<IMapper>();
            var mockRepository = new Mock<IRepository<JobOffer>>();

            mockRepository.Setup(x => x.Add(It.IsAny<JobOffer>()));
            mockMapper.Setup(x => x.Map<JobOffer>(It.IsAny<CreateJobOfferCommand>())).Returns(newJobOffer);

            var getJobOffersQueryHandler = new CreateJobOfferCommandHandler(mockRepository.Object, mockMapper.Object);

            var jobOffer = await getJobOffersQueryHandler.Handle(createJobOfferCommand, new CancellationToken());

            jobOffer.Should().NotBeNull();
            //jobOffer.Id.Should().Be("38656340-8ea7-427c-8587-3e6c6641cb62");
        }
    }
}
