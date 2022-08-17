using JobOpportunities.DataNoSql.CustomLogs;
using Microsoft.Extensions.DependencyInjection;

namespace JobOpportunities.DataNoSql;

public static class DependencyInjection
{
    public static IServiceCollection AddNoSqlServices(this IServiceCollection services)
    {
        services.AddSingleton<IMongoDbLogger, MongoDbLogger>();

        return services;
    }
}
