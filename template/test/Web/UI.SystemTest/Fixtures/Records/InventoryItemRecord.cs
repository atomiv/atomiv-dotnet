using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Records
{
    public class InventoryItemRecord
    {
        // TODO: VC: Make dynamic, use regex
        private const string Currency = "$";

        public InventoryItemRecord(int id, string name, string priceText)
        {
            Id = id;
            Name = name;
            PriceText = priceText;
            PriceCurrency = Currency;
            PriceValue = decimal.Parse(priceText.Substring(1)); // TODO: VC: Use regex
        }

        public InventoryItemRecord(int id, string name, decimal priceValue)
            : this(id, name, $"{Currency}{priceValue}")
        {

        }


        public int Id { get; }

        public string Name { get; }

        public string PriceText { get; }

        public string PriceCurrency { get; }

        public decimal PriceValue { get; }

        public bool Equals(InventoryItemRecord other)
        {
            return Id == other.Id
                && Name == other.Name
                && PriceText == other.PriceText;
        }

        public override bool Equals(object obj)
        {
            var other = obj as InventoryItemRecord;

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
