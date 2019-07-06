namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Interfaces.Records
{
    public interface IProductRecord
    {
        int Id { get; }

        string Name { get; }

        string PriceText { get; }

        string PriceCurrency { get; }

        decimal PriceValue { get; }
    }
}
