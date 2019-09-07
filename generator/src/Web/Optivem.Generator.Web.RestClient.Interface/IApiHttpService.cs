namespace Optivem.Generator.Web.RestClient.Interface
{
    public interface IApiHttpService
    {
        ICustomerHttpService Customers { get; }

        IProductHttpService Products { get; }
    }
}
