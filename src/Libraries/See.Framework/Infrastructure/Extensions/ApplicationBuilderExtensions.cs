using Microsoft.AspNetCore.Builder;

namespace See.Framework.Infrastructure.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void ConfigureRequestPipeline(this IApplicationBuilder applicationBuilder)
    {
        applicationBuilder.UseRouting();
        applicationBuilder.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}