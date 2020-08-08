namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB
{
    public class DbSettings : IDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
