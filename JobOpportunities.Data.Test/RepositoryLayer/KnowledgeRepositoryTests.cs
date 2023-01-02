using FluentAssertions;
using JobOpportunities.CommonInfrastructure.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Implementations;
using JobOpportunities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace JobOpportunities.Data.UnitTest.RepositoryLayer
{
    public class KnowledgeRepositoryTests
    {
        private JobOpportunitiesContext _context = default!;
        private KnowledgeRepository _repository = default!;
        private Guid _createdKnowledgeId;

        [SetUp]
        public async Task Setup()
        {
            await InitializeRepository();
        }

        private async Task InitializeRepository()
        {
            Mock<IHttpContextAccessor> mockHttpContextAccessor = CreateMockedHttpContextAccessor();

            var currentUserService = new CurrentUserService(mockHttpContextAccessor.Object);

            DbContextOptions<JobOpportunitiesContext> dbContextOptions = new DbContextOptionsBuilder<JobOpportunitiesContext>().UseInMemoryDatabase("JobOpportunities").Options;
            _context = new JobOpportunitiesContext(dbContextOptions, currentUserService);

            var logger = Mock.Of<ILogger>();

            _repository = new KnowledgeRepository(_context, logger);
            _repository.Should().NotBeNull();

            await CreateTestKnowledgeOnDataBase();
        }

        private static Mock<IHttpContextAccessor> CreateMockedHttpContextAccessor()
        {
            var loggedUserClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Sid, "37DCDD97-C90B-47E4-A645-A3BE23A78EC1")
            };

            var mockHttpContextAccessor = new Mock<IHttpContextAccessor>();
            mockHttpContextAccessor.Setup(req => req.HttpContext.User.Identity!.IsAuthenticated)
                .Returns(true);
            mockHttpContextAccessor.Setup(req => req.HttpContext.User.Identity!.Name)
                .Returns("Test User");
            mockHttpContextAccessor.Setup(req => req.HttpContext!.User.Claims)
                .Returns(loggedUserClaims);
            return mockHttpContextAccessor;
        }

        private async Task CreateTestKnowledgeOnDataBase()
        {
            Knowledge newKnowledge = new("Senior")
            {
                Description = "Test",
            };

            _context.Knowleadges.Add(newKnowledge);

            _createdKnowledgeId = newKnowledge.Id;

            await _context.SaveChangesAsync();
        }

        [Test]
        public async Task CreateKnowledge_Success()
        {
            Knowledge newKnowledge = new("Junior")
            {
                Description = "Test",
            };

            _repository.Add(newKnowledge);

            bool result = await _repository.SaveAsync();

            result.Should().BeTrue();
        }

        [Test]
        public async Task GetKnowledgeById_Success()
        {
            var dbSeniority = await _repository.GetKnowledgeById(_createdKnowledgeId);
            dbSeniority.Should().NotBeNull();
            dbSeniority.Title.Should().Be("Senior");
            dbSeniority.Description.Should().Be("Test");
        }

        [Test]
        public async Task GetKnowledgeById_Failure_InvalidId()
        {
            using (StringWriter outputStream = new StringWriter())
            {
                Console.SetOut(outputStream);
                await _repository.Invoking(y => y.GetKnowledgeById(Guid.Empty))
                .Should().ThrowAsync<ArgumentException>();

                outputStream.ToString().Should().Contain("Argument Exception in GetKnowledgeById! KnowledgeId  =");
            }
        }

        [Test]
        public async Task GetKnowledgeById_Failure_KnowledgeNotFound()
        {
            await _repository.Invoking(y => y.GetKnowledgeById(new Guid("1F1C2726-E262-4F74-A85A-BA1E515B09A9")))
            .Should().ThrowAsync<KnowledgeNotFoundException>();
        }
    }
}
