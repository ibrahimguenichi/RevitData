using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Net;
using RevitData.ApplicationCore.DTO;
using Autodesk.Revit.DB;

namespace RevitData.DocumentExtractionAddIn
{
    public class AsyncExportHandler : IExternalEventHandler
    {
        public string Name { get; } = "Async Export Handler";
        public string ErrorMessage { get; private set; }
        public Result Result { get; private set; }
        public async void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            try
            {
                var jsonData = JsonConvert.SerializeObject(new Test() { nom = "abbbb", prenom = "vvvvv", Title = doc.Title });
                var response = await ExportBatchAsync(jsonData);
                Result = response.Result;
                if (Result == Result.Failed)
                {
                    ErrorMessage = response.Message;
                    Autodesk.Revit.UI.TaskDialog.Show("Error", $"Failed: {ErrorMessage}");
                }
                else
                {
                    Autodesk.Revit.UI.TaskDialog.Show("Success", "Exported successfully");
                }
            }
            catch (Exception ex)
            {
                Result = Result.Failed;
                ErrorMessage = ex.Message;
                Autodesk.Revit.UI.TaskDialog.Show("Critical Error", ErrorMessage);
            }
        }

        public string GetName()
        {
            return Name;
        }

        public static async Task<(Result Result, string Message)> ExportBatchAsync(string name)
        {
            try
            {
                var response = await DataExtractionAPI.PostBatch("Title", name);

                if (response.StatusCode != HttpStatusCode.OK || !string.IsNullOrEmpty(response.ErrorMessage))
                {
                    return (Result.Failed, response.ErrorMessage ?? "Unknown error");
                }
                return (Result.Succeeded, "Success");
            }
            catch (Exception ex)
            {
                return (Result.Failed, ex.Message);
            }
        }
    }
}
