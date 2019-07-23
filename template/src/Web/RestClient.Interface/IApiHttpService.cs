using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.RestClient.Interface
{
    public interface IApiHttpService
    {
        ICustomerHttpService Customers { get; }

        IProductHttpService Products { get; }
    }
}
