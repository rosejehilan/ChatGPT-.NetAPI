using Newtonsoft.Json;
using System.Text;

if (args.Length > 0)
{
    HttpClient client = new HttpClient();
    client.DefaultRequestHeaders.Add("authorization", "Bearer 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");
    var content = new StringContent("{\"model\": \"text-davinci-001\", \"prompt\": \"" + args[0] + "\",\"temperature\": 1,\"max_tokens\": 100}",
        Encoding.UTF8, "application/json");

    HttpResponseMessage response = await client.PostAsync("\r\nhttps://api.openai.com/v1/completions",content);
    string responseString = await response.Content.ReadAsStringAsync();

    try
    {
var dyData = JsonConvert.DeserializeObject<dynamic>(responseString);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"---> API response is: {dyData!.choices[0].text}");
        Console.ResetColor();
    }
    catch(Exception ex)
    { 
    
    }
    Console.WriteLine(responseString);
}
else
{
    Console.WriteLine("----> You need to provide some input");
}
