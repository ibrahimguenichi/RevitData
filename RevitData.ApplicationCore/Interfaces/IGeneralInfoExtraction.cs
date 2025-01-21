using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Interfaces
{
    public interface IGeneralInfoExtraction
    {
        string GetGUID(Guid guid);
    }
}
