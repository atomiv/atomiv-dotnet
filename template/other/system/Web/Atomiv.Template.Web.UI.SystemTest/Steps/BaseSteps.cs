using Atomiv.Template.Web.UI.SystemTest.Fixtures;

namespace Atomiv.Template.Web.UI.SystemTest.Steps
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