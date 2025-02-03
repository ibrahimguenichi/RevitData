using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore
{
    public class SingletonStorage
    {
        private static SingletonStorage _instance;
        public static SingletonStorage Instance => _instance ??= new SingletonStorage();

        public string DocumentTitle { get; set; }
    }
}
