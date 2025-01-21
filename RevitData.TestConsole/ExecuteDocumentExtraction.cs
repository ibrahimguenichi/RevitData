using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevitData.ApplicationCore;
using RevitData.ApplicationCore.Services;

namespace RevitData.TestConsole
{
    public class ExecuteDocumentExtraction
    {
        public static void ExtractDocument()
        {
            UIAutomationService uiAutomationService = new UIAutomationService();

            uiAutomationService.AutomateDocumentExtraction("C:\\Users\\ibrah\\OneDrive\\Desktop\\TestRevitData\\rac_basic_sample_project.rvt", "Lab1PlaceGroup");

            Console.WriteLine(DocumentStorage.Instance.CurrentDocument.Title.ToString());
        }
    }
}
