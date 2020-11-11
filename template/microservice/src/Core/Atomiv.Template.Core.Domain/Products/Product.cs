using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Products
{
    public class Product : Entity<ProductIdentity>, IReadonlyProduct
    {
        private string _productCode;
        private string _productName;
        private decimal _listPrice;

        public Product(ProductIdentity id, 
            string productCode, 
            string productName, 
            decimal listPrice, 
            bool isListed,
            bool isNew = false)
            : base(id, isNew)
        {
            ProductCode = productCode;
            ProductName = productName;
            ListPrice = listPrice;
            IsListed = isListed;
        }

        public string ProductCode
        {
            get
            {
                return _productCode;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new DomainException("Product code cannot be null or empty");
                }

                _productCode = value;
            }
        }

        public string ProductName
        {
            get
            {
                return _productName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new DomainException("Product name cannot be null or empty");
                }

                _productName = value;
            }
        }

        public decimal ListPrice
        {
            get
            {
                return _listPrice;
            }
            set
            {
                if(value < 0)
                {
                    throw new DomainException("List price cannot be negative");
                }

                _listPrice = value;
            }
        }

        public bool IsListed { get; private set; }

        public void Relist()
        {
            if (IsListed)
            {
                throw new DomainException("Cannot relist product because it is already listed");
            }

            IsListed = true;
        }

        public void Unlist()
        {
            if (!IsListed)
            {
                throw new DomainException("Cannot unlist product because it has already been unlisted");
            }

            IsListed = false;
        }
    }
}