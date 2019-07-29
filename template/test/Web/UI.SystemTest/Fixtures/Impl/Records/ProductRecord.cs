using Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Interfaces.Records;

namespace Optivem.Framework.Infrastructure.Selenium.SystemTest.Fixtures.Records
{
    public class ProductRecord : IProductRecord
    {
        // TODO: VC: Make dynamic, use regex
        private const string Currency = "$";

        public ProductRecord(int id, string name, string priceText)
        {
            Id = id;
            Name = name;
            PriceText = priceText;
            PriceCurrency = Currency;
            PriceValue = decimal.Parse(priceText.Substring(1)); // TODO: VC: Use regex
        }

        public ProductRecord(int id, string name, decimal priceValue)
            : this(id, name, $"{Currency}{priceValue}")
        {

        }


        public int Id { get; }

        public string Name { get; }

        public string PriceText { get; }

        public string PriceCurrency { get; }

        public decimal PriceValue { get; }

        public bool Equals(ProductRecord other)
        {
            return Id == other.Id
                && Name == other.Name
                && PriceText == other.PriceText;
        }

        public override bool Equals(object obj)
        {
            var other = obj as ProductRecord;

            if (other == null)
            {
                return false;
            }

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode()
                ^ Name.GetHashCode()
                ^ PriceText.GetHashCode();
        }
    }
}
