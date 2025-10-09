// See https://aka.ms/new-console-template for more information
using Core.Models;

Console.WriteLine("Hello, World!");

/* Her ser du at vår GenericEntity får vite at den skal jobbe med int datatypen i IntStorer */
GenericEntity<int> IntStorer = new();
IntStorer.StoredValue = 10;

/* Og skal jobbe med string datatypen i StringStorer */
GenericEntity<string> StringStorer = new();
StringStorer.StoredValue = "Hello, world!";

List<float> floats = [];

WeaponList<int> weaponList = new();

weaponList[2] = 234;
Console.WriteLine(weaponList[2]);

for (int i = 0; i < 50; i++)
{
    weaponList.InsertNewWeapon(i);
}




/* Målet vårt for uken er å lage en generisk våpenliste, som kan ta inn forskjellige våpen og lagre disse for oss. Nedenfor ser du eksempler på hvor vi vil være tilslutt. */

/* WeaponList<LongSword> longSwords = [];

WeaponList<Hammer> hammers = []; */