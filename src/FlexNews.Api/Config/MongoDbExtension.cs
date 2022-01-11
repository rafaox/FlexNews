using FlexNews.DataAccessLayer.MongoDbContext;

namespace FlexNews.Api.Config
{
    public static class MongoDbExtension
    {
        public static void ConfigureMongoDb(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<MongoDbContext>();

            MongoDbContext.ConnectionString = config.GetSection("MongoConnection:ConnectionString").Value;
            MongoDbContext.DatabaseName = config.GetSection("MongoConnection:Database").Value;
            MongoDbContext.IsSSL = Convert.ToBoolean(config.GetSection("MongoConnection:IsSSL").Value);
        }
    }
}