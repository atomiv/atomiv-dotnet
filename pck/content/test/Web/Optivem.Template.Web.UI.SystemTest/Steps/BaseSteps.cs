using Optivem.Template.Web.UI.SystemTest.Fixtures;

namespace Optivem.Template.Web.UI.SystemTest.Steps
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