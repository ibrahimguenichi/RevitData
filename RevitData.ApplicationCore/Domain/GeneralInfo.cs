using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Domain
{
    public class GeneralInfo
    {
        public bool IsValidObject { get; set; }
        public string WorksharingProjectGUID { get; set; }
        public string CloudModelGUID { get; set; }
        public string WorksharingCentralGUID { get; set; }

    }
}
