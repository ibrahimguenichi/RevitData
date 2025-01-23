using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitData.ApplicationCore;
using RevitData.Infrastructure;

namespace DocumentExtractionAddIn
{
    [Transaction(TransactionMode.Manual)]
    public class ExtractDocument : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //Get application and document objects  
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            
            DocumentStorage.Title = doc.Title;
            Console.WriteLine($"----------{doc.Title}-----------");

            Autodesk.Revit.UI.TaskDialog.Show("Revit", $"Document has been successfully extracted\n Title: {doc.Title}");

            DataAccess db = new DataAccess();
            Task.Run(async () =>
            {
                await db.InsertDocumentAsync<RevitData.ApplicationCore.Domain.Document>("Document", new RevitData.ApplicationCore.Domain.Document() { Title = doc.Title });
            }).Wait();

            return Result.Succeeded;
        }
    }
}