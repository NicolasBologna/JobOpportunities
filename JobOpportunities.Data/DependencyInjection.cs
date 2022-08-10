﻿using Audit.Core;
using JobOpportunities.Data.GenericRepository;
using JobOpportunities.Data.Identity;
using JobOpportunities.Data.SpecificRepositories;
using JobOpportunities.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobOpportunities.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration config)
    {
        var connectionString = config.GetConnectionString("JobOpportunitiesContextConnection") ?? throw new InvalidOperationException("Connection string 'JobOpportunitiesContextConnection' not found.");
        services.AddDbContext<JobOpportunitiesContext>(options =>
            options.UseSqlServer(connectionString))
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<JobOpportunitiesContext>();

        Configuration.Setup()
        .UseAzureStorageBlobs(configuration => configuration
            .WithConnectionString(config["AuditLogs:ConnectionString"])
            .ContainerName(ev => $"mediatrcommandlogs{DateTime.Today:yyyyMMdd}")
            .BlobName(ev =>
            {
                var currentUser = ev.CustomFields["User"] as CurrentUser;

                return $"{ev.EventType}/{currentUser?.Id}_{DateTime.UtcNow.Ticks}.json";
            })
        );

        services.AddScoped<ICurrentUserService, CurrentUserService>();

        services.AddRepositories();

        return services;
    }
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped(typeof(IReadRepository<>), typeof(ReadOnlyRepository<>));
        #region SpecificRepositories
        services.AddScoped<IJobOfferRepository, JobOfferRepository>();
        services.AddScoped<ICandidatesRepository, CandidatesRepository>();
        #endregion

        return services;
    }
}
