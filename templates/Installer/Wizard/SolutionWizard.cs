using Microsoft.VisualStudio.TemplateWizard;
using Optivem.Template.Wizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Installer.Wizard
{
    public class SolutionWizard : BaseWizard
    {
        public override void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            var form = new InstallerForm();
            form.ShowDialog();

            GlobalParams.AddAllFrom(replacementsDictionary);
            // NOTE: No actions
        }
    }
}
