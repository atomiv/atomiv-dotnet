using Optivem.Atomiv.Web.AspNetCore.RazorPages;
using Optivem.Cli.Core.Application.MyFoos.Requests;
using Optivem.Cli.Core.Application.MyFoos.Responses;
using Optivem.Cli.Core.Application.MyFoos.Services;
using Optivem.Cli.Web.UI.Models;
using Optivem.Cli.Web.UI.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Cli.Web.UI.Services
{
    public class MyFooPageService : PageService<IMyFooService>, IMyFooPageService
    {
        public MyFooPageService(IMyFooService service)
            : base(service)
        {

        }

        public async Task CreateMyFoo(MyFoo myFoo)
        {
            var request = new CreateMyFooRequest
            {
                FirstName = myFoo.FirstName,
                LastName = myFoo.LastName,
            };

            await Service.CreateMyFooAsync(request);
        }

        public async Task<IList<MyFoo>> ListMyFoos()
        {
            var request = new ListMyFoosRequest();
            var response = await Service.ListMyFoosAsync(request);

            return response.Records.Select(Get).ToList();
        }

        private MyFoo Get(ListMyFoosRecordResponse record)
        {
            return new MyFoo
            {
                Id = record.Id,
                FirstName = record.FirstName,
                LastName = record.LastName,
            };
        }
    }
}
