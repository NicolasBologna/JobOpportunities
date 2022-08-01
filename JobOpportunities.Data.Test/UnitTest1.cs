using JobOpportunities.Domain;
using JobOpportunities.Repositories;
using Moq;

namespace JobOpportunities.Data.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Mock<JobOpportunitiesContext> mockValidator = new Mock<JobOpportunitiesContext>();

            var sut = new Repository<JobOffer>(mockValidator.Object);

            var jobOffer = new JobOffer
            {
                CompanyId = new Guid("cb3e09cf-e829-4c22-b8cc-d491e04ee55a"),
                CreationDate = DateTime.Now,
                Description = "asdsadas",
                LastUpdate = DateTime.Now,
                Title = "puesto 1",
                ValidUntil = DateTime.Now.AddDays(20),
            };

            sut.Add(jobOffer);

            mockValidator.Verify(x => x.Add(jobOffer));
        }
    }
}