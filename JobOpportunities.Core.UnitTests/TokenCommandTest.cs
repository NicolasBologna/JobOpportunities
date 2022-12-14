using FluentAssertions;
using JobOpportunities.Core.Common.Services;
using JobOpportunities.Core.Exceptions;
using JobOpportunities.Core.Features.Auth.Commands;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Moq;

namespace JobOpportunities.Core.UnitTests
{
    public class TokenCommandTest
    {
        private TokenCommand _tokenCommand;
        [SetUp]
        public void Setup()
        {
            _tokenCommand = new TokenCommand
            {
                UserName = "MyUserName",
                Password = "MyPassword"
            };
        }

        [Test]
        public async Task ShouldLoginAndCreateToken()
        {
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);

            mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new Candidate("TestFirstName", "TestLastName")
            {
                UserName = "MyUserName",
                Id = new Guid("asdasdasd-21345-f2f24f42-424244"),
            });
            mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(true);
            mockUserManager.Setup(x => x.GetRolesAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(new List<string> { "Admin" });

            var mockConfiguration = new Mock<IConfiguration>();

            mockConfiguration.Setup(c => c["Jwt:Issuer"]).Returns("issuer");
            mockConfiguration.Setup(c => c["Jwt:Audience"]).Returns("audience");
            mockConfiguration.Setup(c => c["Jwt:Key"]).Returns("xyqr6qy23vdruyrsvytsjuyd1swk0e4t");

            var mockAuthService = new Mock<IAuthService>();

            mockAuthService.Setup(authService => authService.GenerateAccessToken(It.IsAny<ApplicationUser>())).ReturnsAsync("token");
            mockAuthService.Setup(authService => authService.GenerateRefreshToken(It.IsAny<Guid>())).ReturnsAsync(new RefreshToken());

            var tokenCommandHandler = new TokenCommandHandler(mockUserManager.Object, mockAuthService.Object);

            var jobOffer = await tokenCommandHandler.Handle(_tokenCommand, new CancellationToken());

            jobOffer.Should().NotBeNull();
            jobOffer.AccessToken.Should().NotBeNull();
            jobOffer.AccessToken.Should().BeOfType<string>();

        }

        [Test]
        public async Task ShouldThrowUnauthorizedExceptionWhenUserNameIsWrong()
        {
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            var mockConfiguration = new Mock<IConfiguration>();

            mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).Returns(Task.FromResult((ApplicationUser)null));

            var mockAuthService = new Mock<IAuthService>();

            mockAuthService.Setup(authService => authService.GenerateAccessToken(It.IsAny<ApplicationUser>())).ReturnsAsync("token");
            mockAuthService.Setup(authService => authService.GenerateRefreshToken(It.IsAny<Guid>())).ReturnsAsync(new RefreshToken());

            var tokenCommandHandler = new TokenCommandHandler(mockUserManager.Object, mockAuthService.Object);

            await tokenCommandHandler.Invoking(y => y.Handle(_tokenCommand, new CancellationToken())).Should().ThrowAsync<UnauthorizedException>();
        }

        [Test]
        public async Task ShouldThrowUnauthorizedExceptionWhenPasswordIsWrong()
        {
            var mockUserManager = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            var mockConfiguration = new Mock<IConfiguration>();

            mockUserManager.Setup(x => x.FindByNameAsync(It.IsAny<string>())).ReturnsAsync(new Candidate("TestFirstName", "TestLastName")
            {
                UserName = "MyUserName",
                Id = new Guid("asdasdasd-21345-f2f24f42-424244"),
            });
            mockUserManager.Setup(x => x.CheckPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(false);


            var mockAuthService = new Mock<IAuthService>();

            mockAuthService.Setup(authService => authService.GenerateAccessToken(It.IsAny<ApplicationUser>())).ReturnsAsync("token");
            mockAuthService.Setup(authService => authService.GenerateRefreshToken(It.IsAny<Guid>())).ReturnsAsync(new RefreshToken());


            var tokenCommandHandler = new TokenCommandHandler(mockUserManager.Object, mockAuthService.Object);

            await tokenCommandHandler.Invoking(y => y.Handle(_tokenCommand, new CancellationToken())).Should().ThrowAsync<UnauthorizedException>();
        }
    }
}
