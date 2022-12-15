using Castle.Core.Resource;
using FluentAssertions;
using JobOpportunities.CommonInfrastructure.Exceptions;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Implementations;
using JobOpportunities.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Security.Claims;

namespace JobOpportunities.Data.UnitTest.RepositoryLayer
{
    public class SeniorityRepositoryTests
    {
        private JobOpportunitiesContext _context;
        private SeniorityRepository _repository;

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

            _repository = new SeniorityRepository(_context);
            _repository.Should().NotBeNull();

            await CreateTestSkillLevelOnDataBase();
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

        private async Task CreateTestSkillLevelOnDataBase()
        {
            Seniority newSkill = new("JAVA TEST")
            {
                Description = "Test",
            };

            _context.Senirorities.Add(newSkill);

            await _context.SaveChangesAsync();
        }

        [Test]
        public async Task CreateSkillLevel_Success()
        {
            Seniority newSkill = new(".NET")
            {
                Description = "Test",
            };

            _repository.Add(newSkill);

            bool result = await _repository.SaveAsync();

            result.Should().BeTrue();
        }

        [Test]
        public async Task CreateSkillLevel_Failure_DoesntHaveName()
        {
            Seniority newSkill = new(null);
            _repository.Add(newSkill);
            bool result = await _repository.SaveAsync();
            result.Should().BeFalse();
        }

        [Test]
        public async Task GetSkillLevelByName_Success()
        {
            Seniority skillLevel = await _repository.GetSenioritylByName("JAVA TEST");
            skillLevel.Should().NotBeNull();

            Seniority dbSkillLevel = _context.Senirorities.First();

            bool skillLevelsAreEqual = dbSkillLevel == skillLevel;

            skillLevel.Name.Should().Be("JAVA TEST");
            skillLevel.Description.Should().Be("Test");
            skillLevelsAreEqual.Should().BeTrue();
        }

        [Test]
        [TestCase("")]
        [TestCase(null)]
        [TestCase("#")]
        [TestCase("$")]
        [TestCase("%")]
        [TestCase("*")]
        public async Task GetSkillLevelByName_Failure_InvalidName(string name)
        {
            await _repository.Invoking(y => y.GetSenioritylByName(name))
                .Should().ThrowAsync<SeniorityNotFoundException>();
        }

        [Test]
        public async Task GetSkillLevelByName_Failure_SkillLevelDoesntExists()
        {
            await _repository.Invoking(y => y.GetSenioritylByName("MISSING"))
                .Should().ThrowAsync<SeniorityNotFoundException>();
        }
    }
}
