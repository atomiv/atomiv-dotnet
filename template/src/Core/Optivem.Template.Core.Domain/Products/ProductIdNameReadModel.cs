using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Products
{
    public class ProductIdNameReadModel : IdNameReadModel<int>
    {
        public ProductIdNameReadModel(int id, string name) : base(id, name)
        {
        }
    }
}
