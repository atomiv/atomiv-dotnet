using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Cli.Core.Domain.MyFoos.Entities;
using Optivem.Cli.Core.Domain.MyFoos.Repositories;
using Optivem.Cli.Core.Domain.MyFoos.ValueObjects;
using Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Records;

namespace Optivem.Cli.Infrastructure.EntityFrameworkCore.MyFoos.Repositories
{
    public class MyFooRepository : Repository<DatabaseContext, MyFoo, MyFooIdentity, MyFooRecord, int>, IMyFooRepository
    {
        public MyFooRepository(DatabaseContext context) : base(context)
        {
        }

        protected override MyFoo GetAggregateRoot(MyFooRecord record)
        {
            var identity = new MyFooIdentity(record.Id);
            return new MyFoo(identity, record.FirstName, record.LastName);
        }

        protected override MyFooIdentity GetIdentity(MyFooRecord record)
        {
            return new MyFooIdentity(record.Id);
        }

        protected override MyFooRecord GetRecord(MyFooIdentity identity)
        {
            return new MyFooRecord
            {
                Id = identity.Id,
            };
        }

        protected override MyFooRecord GetRecord(MyFoo aggregateRoot)
        {
            return new MyFooRecord
            {
                Id = aggregateRoot.Id.Id,
                FirstName = aggregateRoot.FirstName,
                LastName = aggregateRoot.LastName,
            };
        }
    }
}