using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FlexNews.Api.Config
{
    public static class OpenAPIExtensions
    {
        public static IServiceCollection RegisterSwaggerGen(
            this IServiceCollection services,
            string title,
            string description,
            Action<SwaggerGenOptions> configure = null
            )
        {
            return services.AddSwaggerGen(config => config.RegisterVersion("v1", title, description));
        }

        public static IApplicationBuilder RegisterSwaggerUI(
            this IApplicationBuilder app,
            string title,
            IApiVersionDescriptionProvider apiVersionDescriptionProvider,
            Action<SwaggerUIOptions> configure = null
            )
        {
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.DocumentTitle = title;
                config.DocExpansion(DocExpansion.None);
                config.RoutePrefix = string.Empty;
                
                foreach (ApiVersionDescription description in apiVersionDescriptionProvider.ApiVersionDescriptions)
                    config.SwaggerEndpoint(
                        $"/swagger/{description.GroupName}/swagger.json",
                        $"API Docs {description.GroupName.ToLower()}"
                    );

                configure?.Invoke(config);
            });

            return app;
        }

        public static SwaggerGenOptions RegisterVersion(this SwaggerGenOptions options, string version, string title, string description)
        {
            options.SwaggerDoc(version, new OpenApiInfo
            {
                Version = version,
                Title = title,
                Description = description,
                TermsOfService = new Uri("https://example.com/terms"),
                Contact = new OpenApiContact
                {
                    Name = "Example Contact",
                    Url = new Uri("https://example.com/contact")
                },
                License = new OpenApiLicense
                {
                    Name = "Example License",
                    Url = new Uri("https://example.com/license")
                }
            });

            return options;
        }
    }
}