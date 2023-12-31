using Domain.Interfaces.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public static class InfrastructureRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        #region MongoDB
        services.Configure<MongoSettings>(
            configuration.GetSection(nameof(MongoSettings)));

        services.AddSingleton<IMongoSettings>(sp =>
            sp.GetRequiredService<IOptions<MongoSettings>>().Value);
        #endregion

        #region Repositories
        services.AddSingleton<IMongoContext, MongoContext>();
        services.AddSingleton<ISampleRepository, SampleRepository>();
        #endregion

        return services;
    }
}
