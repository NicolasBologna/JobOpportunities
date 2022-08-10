using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Domain;
using Moq;

namespace JobOpportunities.Data.UnitTest
{
    public class JobOfferRepositoryTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldReturn()
        {
            Mock<JobOpportunitiesContext> mockValidator = new Mock<JobOpportunitiesContext>();

            var sut = new GenericRepository<JobOffer>(mockValidator.Object);

            var jobOffer = new JobOffer
            {
                CompanyId = new Guid("cb3e09cf-e829-4c22-b8cc-d491e04ee55a"),
                Description = "asdsadas",
                Title = "puesto 1",
                ValidUntil = DateTime.Now.AddDays(20),
            };

            sut.Add(jobOffer);

            mockValidator.Verify(x => x.Add(jobOffer));
        }
    }
}
