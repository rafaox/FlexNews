using FlexNews.Services.Contracts;
using FlexNews.Services.Repositories;

namespace FlexNews.Api.Config
{
    public static class ServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<INewsRepository, NewsRepository>();
        }
    }
}