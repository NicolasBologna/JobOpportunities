using JobOpportunities.API;
using JobOpportunities.API.Middlewares;
using JobOpportunities.Core;
using JobOpportunities.Data;
using JobOpportunities.DataNoSql;
using JobOpportunities.Domain;
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
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowOrigin");

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
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

    context.Database.EnsureCreated();

    if (userManager.Users.Count() <= 2)
    {
        logger.LogInformation("Creando usuario de prueba");

        var newUser = new ApplicationUser("Test", "User")
        {
            Email = "test@demo.com",
            UserName = "test.demo"
        };

        await userManager.CreateAsync(newUser, "P@ss.W0rd");
        await roleManager.CreateAsync(new IdentityRole
        {
            Name = "Admin"
        });
        await roleManager.CreateAsync(new IdentityRole
        {
            Name = "AnotherRole"
        });

        await userManager.AddToRoleAsync(newUser, "Admin");
        await userManager.AddToRoleAsync(newUser, "AnotherRole");
    }
}