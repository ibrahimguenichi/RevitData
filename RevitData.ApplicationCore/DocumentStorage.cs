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
        public static string Title;

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
    }
}
