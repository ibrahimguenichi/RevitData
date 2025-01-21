using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitData.ApplicationCore;

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

            DocumentStorage.Instance.CurrentDocument = doc;

            TaskDialog.Show("Revit", "Document has been successfully extracted");

            return Result.Succeeded;
        }
    }
}