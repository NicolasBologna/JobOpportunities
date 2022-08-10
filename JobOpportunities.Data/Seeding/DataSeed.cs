//using JobOpportunities.Domain;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

//namespace JobOpportunities.Data.Seeding
//{
//    public static class DataSeed
//    {
//        static async Task SeedData(WebApplication app)
//        {
//            var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
//            using var scope = scopeFactory.CreateScope();

//            var context = scope.ServiceProvider.GetRequiredService<JobOpportunitiesContext>();
//            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
//            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//            var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

//            context.Database.EnsureCreated();

//            if (userManager.Users.Count() <= 2)
//            {
//                logger.LogInformation("Creando usuario de prueba");

//                var newUser = new ApplicationUser("Test", "User")
//                {
//                    Email = "test@demo.com",
//                    UserName = "test.demo"
//                };

//                await userManager.CreateAsync(newUser, "P@ss.W0rd");
//                await roleManager.CreateAsync(new IdentityRole
//                {
//                    Name = "Admin"
//                });
//                await roleManager.CreateAsync(new IdentityRole
//                {
//                    Name = "AnotherRole"
//                });

//                //await userManager.AddToRoleAsync(newUser, "Admin");
//                await userManager.AddToRoleAsync(newUser, "AnotherRole");
//            }
//        }
//    }
//}
