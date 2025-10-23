using System;
using System.Net;
using System.Text;

namespace HttpWebServer.WebServers;

public class SimpleHttpServer : IDisposable
{
    private readonly HttpListener _listener = new();

    public SimpleHttpServer() => ListenAsync();

    private async void ListenAsync()
    {
        _listener.Prefixes.Add("http://localhost:1337/");

        _listener.Start();

        var context = await _listener.GetContextAsync();

        if (string.Equals(context.Request.HttpMethod, "get", StringComparison.OrdinalIgnoreCase))
        {
            string responseMessage = $"You asked for the following resource: {context.Request.RawUrl}";

            context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseMessage);
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            using var outputStream = context.Response.OutputStream;
            using var streamWriter = new StreamWriter(outputStream);
            await streamWriter.WriteAsync(responseMessage);
        }
    }
    public void Dispose() => _listener.Close();
}
