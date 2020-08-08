namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB
{
    public interface IDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
