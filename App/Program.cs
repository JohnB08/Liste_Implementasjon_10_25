// See https://aka.ms/new-console-template for more information
using Core.Models;

Console.WriteLine("Hello, World!");

var client = new HttpClient();

var response = await client.GetAsync("https://www.nrk.no");

Console.WriteLine(response.IsSuccessStatusCode);

Console.WriteLine(response.StatusCode);

var headers = response.Content.Headers;

Console.WriteLine(headers.ContentType);

Console.WriteLine(headers.ContentLength);

using var fileStream = File.Create("result.html");
await response.Content.CopyToAsync(fileStream);



/* Målet vårt for uken er å lage en generisk våpenliste, som kan ta inn forskjellige våpen og lagre disse for oss. Nedenfor ser du eksempler på hvor vi vil være tilslutt. */

/* WeaponList<LongSword> longSwords = [];

WeaponList<Hammer> hammers = []; */