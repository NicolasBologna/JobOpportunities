using JobOpportunities.CommonInfrastructure.Exceptions.DBExceptions;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories.Implementations;
using JobOpportunities.Data.UnitTest.Common;
using JobOpportunities.Data.UnitTest.Stubs;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System.Security.Claims;

namespace JobOpportunities.Data.UnitTest.RepositoryLayer
{
    public class SkillRepositoryTests
    {
        private JobOpportunitiesContext _context;
        private SkillRepository _repository;

        [SetUp]
        public async Task Setup()
        {
            await InitializeRepository();
        }

        private async Task InitializeRepository()
        {
            Mock<IHttpContextAccessor> mockHttpContextAccessor = CreateMockedHttpContextAccessor();

            var logger = Mock.Of<ILogger>();

            var currentUserService = new CurrentUserService(mockHttpContextAccessor.Object);

            DbContextOptions<JobOpportunitiesContext> dbContextOptions = new DbContextOptionsBuilder<JobOpportunitiesContext>()
                .UseInMemoryDatabase("JobOpportunities").Options;
            _context = new JobOpportunitiesContext_Stub(dbContextOptions, currentUserService);

            _repository = new SkillRepository(_context, logger);
            _repository.Should().NotBeNull();

            //await CreateTestSkillOnDataBase();
        }

        [Test]
        public async Task CreateSkill_Success()
        {

        }

        static Guid?[][] NullAndEmptyGuid = new Guid?[][]
        {
            new Guid?[] { Guid.Empty, new Guid("8BFF4FF1-30BA-4210-9DBE-91F477DF8C6D") },
            new Guid?[] { new Guid("8BFF4FF1-30BA-4210-9DBE-91F477DF8C6D"), Guid.Empty }
        };

        [Test]
        [TestCaseSource(nameof(NullAndEmptyGuid))]
        //[TestCase(Guid.Empty, new Guid("8BFF4FF1-30BA-4210-9DBE-91F477DF8C6D"))] esto no funciona pq los atributos en C# no aceptan algunos tipos
        //[TestCase(new Guid("8BFF4FF1-30BA-4210-9DBE-91F477DF8C6D"), Guid.Empty)]
        public async Task CreateSkill_Failure_InvalidInputs(Guid seniorityId, Guid knowleadgeId)
        {
            await _repository.Invoking(y => y.CreateSkill(seniorityId, knowleadgeId))
                .Should().ThrowAsync<ArgumentException>();
        }

        [Test]
        public async Task CreateSkill_Failure_DatabaseError()
        {
            await _repository.Invoking(y => y.CreateSkill(DefaultGUIDS.DefaultCreationForFailureGUID, DefaultGUIDS.DefaultCreationForFailureGUID))
                .Should().ThrowAsync<CouldNotAddSkillToDatabaseException>();
        }

        //[Test]
        //public async Task CreateSkill_Failure_DoesntHaveName()
        //{
        //    Skill newSkill = new(null);
        //    _repository.Add(newSkill);
        //    bool result = await _repository.SaveAsync();
        //    result.Should().BeFalse();
        //}

        //[Test]
        //public async Task GetSkillByName_Success()
        //{
        //    Skill skill = await _repository.GetSkilllByName("JAVA TEST");
        //    skill.Should().NotBeNull();

        //    Skill dbSkill = _context.Senirorities.First();

        //    bool skillsAreEqual = dbSkill == skill;

        //    skill.Name.Should().Be("JAVA TEST");
        //    skill.Description.Should().Be("Test");
        //    skillsAreEqual.Should().BeTrue();
        //}

        //[Test]
        //[TestCase("")]
        //[TestCase(null)]
        //[TestCase("#")]
        //[TestCase("$")]
        //[TestCase("%")]
        //[TestCase("*")]
        //public async Task GetSkillByName_Failure_InvalidName(string name)
        //{
        //    await _repository.Invoking(y => y.GetSkilllByName(name))
        //        .Should().ThrowAsync<SkillNotFoundException>();
        //}

        //[Test]
        //public async Task GetSkillByName_Failure_SkillDoesntExists()
        //{
        //    await _repository.Invoking(y => y.GetSkilllByName("MISSING"))
        //        .Should().ThrowAsync<SkillNotFoundException>();
        //}

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

        //private async Task CreateTestSkillOnDataBase()
        //{
        //    Skill newSkill = new()
        //    {
        //        Description = "Test",
        //    };

        //    _context.Senirorities.Add(newSkill);

        //    await _context.SaveChangesAsync();
        //}
    }
}
