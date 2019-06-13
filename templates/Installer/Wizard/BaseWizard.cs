using EnvDTE;
using Microsoft.VisualStudio.TemplateWizard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Template.Installer.Wizard
{
    public class BaseWizard : IWizard
    {
        public virtual void BeforeOpeningFile(ProjectItem projectItem)
        {
            // NOTE: No actions
        }

        public virtual void ProjectFinishedGenerating(Project project)
        {
            // NOTE: No actions
        }

        public virtual void ProjectItemFinishedGenerating(ProjectItem projectItem)
        {
            // NOTE: No actions
        }

        public virtual void RunFinished()
        {
            // NOTE: No actions
        }

        public virtual void RunStarted(object automationObject, Dictionary<string, string> replacementsDictionary, WizardRunKind runKind, object[] customParams)
        {
            // NOTE: No actions
        }

        public virtual bool ShouldAddProjectItem(string filePath)
        {
            return false;
            // NOTE: No actions
        }
    }
}
