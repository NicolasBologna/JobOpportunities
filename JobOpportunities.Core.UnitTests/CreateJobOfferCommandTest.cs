using AutoMapper;
using FluentAssertions;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.JobOffers.Commands;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
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
            //var mockCompanyRepository = new Mock<IGenericRepository<Company>>();
            var mockJobOfferRepository = new Mock<IGenericRepository<JobOffer>>();

            //mockCompanyRepository.Setup(x => x.ItemExists(It.IsAny<Guid>())).ReturnsAsync(true);
            mockJobOfferRepository.Setup(x => x.Add(It.IsAny<JobOffer>()));
            mockMapper.Setup(x => x.Map<JobOffer>(It.IsAny<CreateJobOfferCommand>())).Returns(newJobOffer);

            //var getJobOffersQueryHandler = new CreateJobOfferCommandHandler(mockJobOfferRepository.Object, mockMapper.Object);

            //var response = await getJobOffersQueryHandler.Handle(createJobOfferCommand, new CancellationToken());

            //response.Should().NotBeNull();
        }

        [Test]
        public async Task ShouldThrowNotFoundExceptionWhenCompanyDoesntExists()
        {
            var mockMapper = new Mock<IMapper>();
            //var mockCompanyRepository = new Mock<IGenericRepository<Company>>();
            var mockJobOfferRepository = new Mock<IGenericRepository<JobOffer>>();

            //mockCompanyRepository.Setup(x => x.ItemExists(It.IsAny<Guid>())).ReturnsAsync(false);
            mockJobOfferRepository.Setup(x => x.Add(It.IsAny<JobOffer>()));
            mockMapper.Setup(x => x.Map<JobOffer>(It.IsAny<CreateJobOfferCommand>())).Returns(newJobOffer);

            //var createJobOffersQueryHandler = new CreateJobOfferCommandHandler(mockJobOfferRepository.Object, mockMapper.Object);

            //await createJobOffersQueryHandler.Invoking(y => y.Handle(createJobOfferCommand, new CancellationToken())).Should().ThrowAsync<NotFoundException>();
        }
    }
}
