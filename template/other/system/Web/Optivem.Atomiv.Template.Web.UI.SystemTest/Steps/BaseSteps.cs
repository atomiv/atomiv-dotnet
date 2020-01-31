using Optivem.Atomiv.Template.Web.UI.SystemTest.Fixtures;

namespace Optivem.Atomiv.Template.Web.UI.SystemTest.Steps
{
    public class BaseSteps
    {
        public BaseSteps(IAppFixture fixture)
        {
            Fixture = fixture;
        }

        public IAppFixture Fixture { get; }
    }
}