// See https://aka.ms/new-console-template for more information
using HttpWebServer.WebServers;

/* Console.WriteLine("Hello, World!");

var client = new HttpClient();

using var server1 = new SimpleHttpServer();

var response = await client.GetStringAsync("http://localhost:1337/readme.txt");

Console.WriteLine(response); */


var webServer = new ComplexWebServer("http://localhost:9001/", "/webroot");

try
{
    webServer.Start();
    Console.WriteLine("Server is running, press any key to exit...");
    Console.ReadKey();
}
finally
{
    webServer.Stop();
}


