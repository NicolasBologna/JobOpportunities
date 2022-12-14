using FluentValidation;
using JobOpportunities.Core.Behaviours;
using JobOpportunities.Core.Common.Services;
using JobOpportunities.Core.Features.JobOffers.Queries;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace JobOpportunities.Core;

public static class DependencyInjection
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(GetJobOfferQuery).Assembly);

        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AuditLogsBehavior<,>));

        services.AddTransient<IAuthService, AuthService>();

        services.AddMediatR(Assembly.GetExecutingAssembly(), typeof(GetJobOfferQuery).Assembly);

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
