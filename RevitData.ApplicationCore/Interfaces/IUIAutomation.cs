using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Automation;

namespace RevitData.ApplicationCore.Interfaces
{
    public interface IUIAutomation
    {
        string GetLatestInstalledRevitVersion();
        public void LaunchRevitAsProcess(string revitPath);
        public void CloseRevit();
        public void AutomateAddInTrigger(string addInName);
        public void AutomateDocumentExtraction(string revitPath, string addInName);
    }
}
