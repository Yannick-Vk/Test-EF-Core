using Microsoft.EntityFrameworkCore;
using Test_Ef.Models;

using var context = new LandContext();

Console.WriteLine("--- Landen georderd op Naam ---");
foreach (var land in context.Landen.OrderBy(l => l.Naam)) {
    Console.WriteLine($"{land.LandCode}:  {land.Naam}");
}

Console.WriteLine("----------");
Console.Write("Landcode> ");
var inputStr = Console.ReadLine()?.Trim();
if (string.IsNullOrEmpty(inputStr)) {
    PrintError("Landcode mag niet leeg zijn.");
    return;
}
if (inputStr.Length != 3) {
    PrintError("Landcode moet 3 karakters lang zijn.");
    return;
}

var gevondenLand = context.Landen
    .Include(l=>l.Steden)
    .Include(l=> l.Talen)
    .FirstOrDefault(l => l.LandCode == inputStr.ToUpper());

if (gevondenLand is null) {
    PrintError($"Landcode `{inputStr}` niet gevonden.");
    return;
}

Console.WriteLine($"--- {gevondenLand.Naam} ---");
Console.WriteLine("Steden: ");
foreach (var stad in gevondenLand.Steden) {
    Console.WriteLine($"\t{stad.Naam}");
}

Console.WriteLine("Talen: ");
foreach (var taal in gevondenLand.Talen) {
    Console.WriteLine($"\t{taal.Naam}");
}

Console.WriteLine("----------");

Console.Write("Nieuwe stad toevoegen> ");
var nieuweStad = Console.ReadLine()?.Trim();
if (string.IsNullOrEmpty(nieuweStad)) {
    PrintError("NieuweStad mag niet leeg.");
    return;
}

var stadObj = new Stad {
    Naam = nieuweStad,
    LandCode = gevondenLand.LandCode,
};

context.Steden.Add(stadObj);
context.SaveChanges();
Console.WriteLine($"Stad `{nieuweStad}` toegevoegd");

return;


void PrintError(string message) {
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine(message);
    Console.ForegroundColor = ConsoleColor.White;
}