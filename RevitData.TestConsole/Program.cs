using RevitData.ApplicationCore;
using RevitData.Infrastructure;
using RevitData.TestConsole;
using System;
using Newtonsoft.Json;

namespace MyConsoleApp
{
    class Program
    {
        static async void Main(string[] args)
        {
            var data = JsonConvert.SerializeObject(new test() { nom = "abc", prenom = "azdsda" });

            var response = await APICall.PostBatch("Title", data);

            if (response.StatusCode != System.Net.HttpStatusCode.OK || !string.IsNullOrEmpty(response.ErrorMessage))
            {
                Console.WriteLine("Failed: " + response.ErrorMessage ?? "Unknown error");
            }
            else
            {
                Console.WriteLine("Success");
            }
        }
    }
}