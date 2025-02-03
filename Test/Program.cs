using Newtonsoft.Json;
using TestConsole;

var data = JsonConvert.SerializeObject(new Test() { nom = "abc", prenom = "cqsdfsd"});

var response = await APICall.PostBatch("Title", data);

Console.WriteLine($"Status Code: {response.StatusCode}");
Console.WriteLine($"Response Content: {response.Content}");
Console.WriteLine($"Error Message: {response.ErrorMessage}");