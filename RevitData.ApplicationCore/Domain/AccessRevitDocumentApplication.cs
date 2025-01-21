using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Domain
{
    public class AccessRevitDocumentApplication : IExternalApplication
    {

        public Result OnStartup(UIControlledApplication application)
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "--run-external-command")
            {
                // Queue the external command to run
                //application.Idling += ExecuteExternalCommandOnStartup;
            }

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            try
            {
                Console.WriteLine("Revit: External Application Stopped");
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Revit: Error during shutdown: {ex.Message}");
                return Result.Failed;
            }
        }



    }
}
