using Cli.Web.UI.Models;
using Cli.Web.UI.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cli.Web.UI.Services.Fake
{
    public class FakeMyFooPageService : IMyFooPageService
    {
        public Task CreateMyFoo(MyFoo myFoo)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<MyFoo>> ListMyFoos()
        {
            var myFoos = new List<MyFoo>
            {
                new MyFoo
                {
                    FirstName = "me",
                    LastName = "you"
                },

                new MyFoo
                {
                    FirstName = "me2",
                    LastName = "you2"
                },
            };

            return Task.FromResult((IList<MyFoo>) myFoos);
        }
    }
}
