using LinqToDB.Mapping;
using See.Demo.Models;

namespace See.Demo.Extensions;

public static class LinqToDbExtensions
{
    public static void AddMappingSchema(this IServiceCollection services)
    {
        var mappingSchema = new MappingSchema();
        var builder = mappingSchema.GetFluentMappingBuilder();
        builder.Entity<Member>().HasPrimaryKey(x => x.Id);
        services.AddSingleton(mappingSchema);
    }
}