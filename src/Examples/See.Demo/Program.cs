using Autofac.Extensions.DependencyInjection;
using See.Framework.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Load config files
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Configuration.AddJsonFile("appsettings.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true);
builder.Configuration.AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.Local.json", true, true);
builder.Configuration.AddEnvironmentVariables();

// Add services to the application and configure service provider
builder.Services.ConfigureApplicationServices(builder);

var app = builder.Build();

app.ConfigureRequestPipeline();

app.Run();