using JobOpportunities.API;
using JobOpportunities.API.Middlewares;
using JobOpportunities.Core;
using JobOpportunities.Data;
using JobOpportunities.DataNoSql;
using JobOpportunities.Domain;
using JobOpportunities.Domain.Users;
using Microsoft.AspNetCore.Identity;
using MongoDB.Driver;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    //.WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .WriteTo.MongoDBBson("mongodb://localhost:27017/JobOpportunities", collectionName: "Logs")
    //.WriteTo.MongoDBBson(databaseUrl: "mongodb://serilogMongo:<PASSWORD>@ac-tz1xyaf-shard-00-00.vzwjbbc.mongodb.net/JobOpportunities", collectionName: "JobOpportunitiesLogs")
    .CreateLogger();

builder.Services.AddWebApiServices();
builder.Services.AddDataServices(builder.Configuration);
builder.Services.AddCoreServices();
builder.Services.AddSecurityServices(builder.Configuration);
builder.Services.AddNoSqlServices();


var app = builder.Build();

app.UseMiddleware<ResponseTimeMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowOrigin");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();



try
{
    Log.Information("Iniciando Web API");

    await SeedData();

    Log.Information("Corriendo en:");
    Log.Information("https://localhost:7278");
    Log.Information("http://localhost:5278");

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");

    return;
}
finally
{
    Log.CloseAndFlush();
}


async Task SeedData()
{
    var scopeFactory = app!.Services.GetRequiredService<IServiceScopeFactory>();
    using var scope = scopeFactory.CreateScope();

    var context = scope.ServiceProvider.GetRequiredService<JobOpportunitiesContext>();
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    context.Database.EnsureCreated();

    if (roleManager.Roles.Count() <= 2)
    {
        await roleManager.CreateAsync(new IdentityRole<Guid>
        {
            Name = "Admin"
        });
        await roleManager.CreateAsync(new IdentityRole<Guid>
        {
            Name = "Candidate"
        });
        await roleManager.CreateAsync(new IdentityRole<Guid>
        {
            Name = "CompanyAgent"
        });
    }

    if (userManager.Users.Count() <= 2)
    {
        logger.LogInformation("Creando usuario de prueba");

        var newUser = new Admin("Test", "User")
        {
            Email = "test@demo.com",
            UserName = "test.demo"
        };

        await userManager.CreateAsync(newUser, "P@ss.W0rd");

        await userManager.AddToRoleAsync(newUser, "Admin");
        await userManager.AddToRoleAsync(newUser, "AnotherRole");
    }
}