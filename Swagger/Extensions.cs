using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace BAS24.Libs.Swagger;

public static class Extensions
{
    public static IServiceCollection AddSwagger(this IServiceCollection services, string? docFileName = null)
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            // c.SwaggerDoc("v1", new OpenApiInfo { Title = "UNT SD Development APIs", Version = "v1" });

            c.ExampleFilters();

            //c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id

            c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            //c.OperationFilter()
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
                    new List<string>()
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, docFileName ?? "BAS24.Api.xml");
            c.IncludeXmlComments(filePath);
            c.OperationFilter<
                AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
            // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

            // add Security information to each operation for OAuth2
            //c.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        services.AddSwaggerExamplesFromAssemblyOf<TestExample>();
        return services;
    }

    public static IServiceCollection AddSwagger<THeader>(this IServiceCollection services, string? docFileName = null)
        where THeader : IOperationFilter
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c =>
        {
            // c.SwaggerDoc("v1", new OpenApiInfo { Title = "UNT SD Development APIs", Version = "v1" });

            c.ExampleFilters();

            //c.OperationFilter<AddHeaderOperationFilter>("correlationId", "Correlation Id for the request", false); // adds any string you like to the request headers - in this case, a correlation id

            //c.OperationFilter<AddResponseHeadersFilter>(); // [SwaggerResponseHeader]

            c.OperationFilter<THeader>();
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description =
                    "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey
            });
            //c.OperationFilter()
            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                        { Reference = new OpenApiReference { Id = "Bearer", Type = ReferenceType.SecurityScheme } },
                    new List<string>()
                }
            });

            var filePath = Path.Combine(AppContext.BaseDirectory, docFileName ?? "BAS24.Api.xml");
            c.IncludeXmlComments(filePath);
            c.OperationFilter<
                AppendAuthorizeToSummaryOperationFilter>(); // Adds "(Auth)" to the summary so that you can see which endpoints have Authorization
            // or use the generic method, e.g. c.OperationFilter<AppendAuthorizeToSummaryOperationFilter<MyCustomAttribute>>();

            // add Security information to each operation for OAuth2
            //c.OperationFilter<SecurityRequirementsOperationFilter>();
        });
        services.AddSwaggerExamplesFromAssemblyOf<TestExample>();
        return services;
    }
}