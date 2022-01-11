using FlexNews.DataAccessLayer.Contracts;
using MongoDB.Driver;

namespace FlexNews.DataAccessLayer.MongoDbContext
{
    public class MongoDbContext
    {
        public static string ConnectionString { get; set; }
        public static string DatabaseName { get; set; }
        public static bool IsSSL { get; set; }
        private readonly IMongoDatabase _mongoDb;

        public MongoDbContext()
        {
            try
            {
                MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(ConnectionString));
                if (IsSSL)
                {
                    settings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
                }

                var mongoClient = new MongoClient(settings);
                _mongoDb = mongoClient.GetDatabase(DatabaseName);
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to connect to mongo server.", ex);
            }
        }

        public IMongoCollection<T> GetCollection<T>(string name) where T : IEntity
        {
            return _mongoDb.GetCollection<T>(name);
        }
    }
}