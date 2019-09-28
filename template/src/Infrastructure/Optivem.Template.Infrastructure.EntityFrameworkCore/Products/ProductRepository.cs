using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Products;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Products
{
    public class ProductRepository : CrudRepository<DatabaseContext, Product, ProductIdentity, ProductRecord, int>, IProductRepository
    {
        public ProductRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<Product>> PageAsync(int page, int size)
        {
            // TODO: VC: Move to base

            var skip = page * size;
            var records = await Context.Set<ProductRecord>().AsNoTracking()
                .Skip(skip)
                .Take(size)
                .ToListAsync();
            return Mapper.Map<IEnumerable<ProductRecord>, IEnumerable<Product>>(records);
        }
    }
}
