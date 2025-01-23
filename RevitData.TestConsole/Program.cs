using RevitData.ApplicationCore;
using RevitData.TestConsole;
using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            ExecuteDocumentExtraction.ExtractDocument();
            Console.WriteLine($"-----{DocumentStorage.Title}-------");
        }
    }
}