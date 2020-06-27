namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
