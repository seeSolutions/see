using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace See.Framework.Infrastructure.Extensions;

public static class ServiceCollectionExtensions
{
    public static void ConfigureApplicationServices(this IServiceCollection services, WebApplicationBuilder builder)
    {
        services.AddControllers();
    }
}