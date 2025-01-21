using RevitData.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Services
{
    public class GenralInfoExtractionService : IGeneralInfoExtraction
    {
        public string GetGUID(Guid guid)
        {
            return guid.ToString();
        }
    }
}
