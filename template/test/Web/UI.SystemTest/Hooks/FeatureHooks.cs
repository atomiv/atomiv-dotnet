using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Optivem.Template.Web.UI.SystemTest.Hooks
{
    [Binding]
    public sealed class FeatureHooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        // NOTE: Method must be static // TODO: VC: Add to docs
        [BeforeFeature]
        public static void BeforeFeature()
        {
            //TODO: implement logic that has to run before executing each scenario
        }

        // NOTE: Method must be static // TODO: VC: Add to docs
        [AfterFeature]
        public static void AfterFeature()
        {

            //TODO: implement logic that has to run after executing each scenario
        }
    }
}
