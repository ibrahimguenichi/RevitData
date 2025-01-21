using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitData.ApplicationCore.Domain
{
    public class RevitFile
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public RevitFileType FileType { get; set; }
        public ulong FileSize { get; set; }

        public RevitFile(string filePath)
        {
            this.FilePath = filePath;
            this.FileName = System.IO.Path.GetFileName(filePath);
            this.FileSize = (ulong)new System.IO.FileInfo(filePath).Length;
            //this.FileType = Path.GetExtension(filePath).ToLower() == ".rfa" ? RevitFileType.family : RevitFileType.project;
        }
    }
}
