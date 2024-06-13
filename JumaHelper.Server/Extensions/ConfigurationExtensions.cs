using System.Reflection;
using JumaHelper.Server.Contexts;
using Serilog;
using Serilog.Events;

namespace JumaHelper.Server.Extensions;

public static class ConfigurationExtensions
{
    public static IServiceCollection ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.ConfigureSerilog();

        var services = builder.Services;

        services.AddCors(options =>
        {
            options.AddPolicy("AllowCors", policyBuilder =>
            {
                policyBuilder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
            });
        });

        // Add services to the container.

        services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddOpenApiDocument();
        services.AddAutoMapper(exp =>
        {
            exp.AddMaps(Assembly.GetExecutingAssembly());
        });


        services.AddDbContext<AppDbContext>(o =>
        {
            o.UseSqlite(builder.Configuration.GetConnectionString("SqLite"));
        });

        return services;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        UseCustomExceptionHandling(app);

        UseSerilogRequestLogging(app);

        app.UseDefaultFiles();
        app.UseStaticFiles();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors("AllowCors");

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.MapFallbackToFile("/index.html");

        return app;
    }

    private static void UseSerilogRequestLogging(WebApplication app)
    {
        app.UseSerilogRequestLogging(options =>
        {
            // Customize the message template
            options.MessageTemplate = "Handled {RequestPath}";

            // Emit debug-level events instead of the defaults
            // ReSharper disable once UnusedParameter.Local
            options.GetLevel = (httpContext,
                // ReSharper disable once UnusedParameter.Local
                elapsed,
                // ReSharper disable once UnusedParameter.Local
                ex) => LogEventLevel.Debug;

            // Attach additional properties to the request completion event
            options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
            {
                diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
                diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
            };
        });
    }

    private static void UseCustomExceptionHandling(WebApplication app)
    {
        app.Use(async (context, next) =>
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await context.Response.WriteAsJsonAsync(new
                {
                    Error = "Error Occured",
                    Message = e.ToString()
                });
            }
        });
    }

    public static IServiceCollection ConfigureSerilog(this WebApplicationBuilder webApplicationBuilder)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(webApplicationBuilder.Configuration)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .CreateBootstrapLogger();

        webApplicationBuilder.Services.AddSerilog((services, lc) => lc
            .ReadFrom.Configuration(webApplicationBuilder.Configuration)
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .MinimumLevel.Override("Microsoft.AspNetCore.Hosting", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Mvc", LogEventLevel.Warning)
            .MinimumLevel.Override("Microsoft.AspNetCore.Routing", LogEventLevel.Warning)
            .ReadFrom.Services(services));

        return webApplicationBuilder.Services;
    }
}