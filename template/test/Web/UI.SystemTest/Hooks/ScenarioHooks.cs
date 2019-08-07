using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Hooks
{
    [Binding]
    public sealed class ScenarioHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        [BeforeScenario]
        public static void BeforeScenario()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        [AfterScenario]
        public static void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
