using System;
using System.Net;
using System.Text;

namespace HttpWebServer.WebServers;

public class ComplexWebServer
{
    private HttpListener _listener;

    private string _baseFolder;

    public ComplexWebServer(string socketInfo, string baseFolder)
    {
        _listener = new();
        _listener.Prefixes.Add(socketInfo);
        _baseFolder = Directory.GetCurrentDirectory() + baseFolder;
    }

    private async void ProcessRequestAsync(HttpListenerContext context)
    {
        try
        {
            var fileName = Path.GetFileName(context.Request.RawUrl);
            var filePath = Path.Combine(_baseFolder, fileName!);

            byte[] responseMessage;

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Resource not found: {filePath}");
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                responseMessage = Encoding.UTF8.GetBytes("Sorry, that file doesn't exists.");
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.OK;
                responseMessage = await File.ReadAllBytesAsync(filePath);
            }
            context.Response.ContentLength64 = responseMessage.Length;

            using var outputStream = context.Response.OutputStream;
            await outputStream.WriteAsync(responseMessage);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing request: {ex.Message}");
        }
    }

    public async void Start()
    {
        _listener.Start();

        while (true)
        {
            try
            {
                var context = await _listener.GetContextAsync();
                Task.Run(() => ProcessRequestAsync(context));
            }
            catch (HttpListenerException) { break; }
            catch (InvalidOperationException) { break; }
        }
    }

    public void Stop() => _listener.Stop();

}
