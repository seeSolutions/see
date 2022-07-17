using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using See.Data;
using See.Data.DataProviders;

namespace See.Framework.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        // controllers and routes
        services.AddControllers();
        
        // data layer
        services.AddTransient<ISeeDataProvider, MySqlDataProvider>();

        // repositories
        services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
    }
}