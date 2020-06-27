namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public interface IDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
