using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitData.ApplicationCore;
using RevitData.Infrastructure;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Net;
using RevitData.DocumentExtractionAddIn;
using RevitData.ApplicationCore.DTO;
using Newtonsoft.Json;

namespace DocumentExtractionAddIn
{
    [Transaction(TransactionMode.ReadOnly)]
    public class ExtractDocument : IExternalCommand
    {
        private static readonly AsyncExportHandler _handler = new AsyncExportHandler();
        private static readonly ExternalEvent _externalEvent = ExternalEvent.Create(_handler);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {   
            try
            {
                // Get application and document objects
                UIApplication uiapp = commandData.Application;
                Document doc = uiapp.ActiveUIDocument.Document;

                _externalEvent.Raise();

                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                string stackTrace = ex.StackTrace;
                Autodesk.Revit.UI.TaskDialog.Show("Error", $"An error occurred: {ex.Message}");
                return Result.Failed;
            }
        }
    }

}