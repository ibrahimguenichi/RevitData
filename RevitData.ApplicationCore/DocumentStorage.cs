using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore
{
    public class DocumentStorage
    {
        private static DocumentStorage _instance;
        private Document _document;

        private DocumentStorage() { }

        // Public static property to access the singleton instance
        public static DocumentStorage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DocumentStorage();
                }
                return _instance;
            }
        }

        // Property to get or set the document
        public Document CurrentDocument
        {
            get { return _document; }
            set { _document = value; }
        }
    }
}
