using KempingFoglalas;
List<Foglalas> adatok=new List<Foglalas>();
Console.WriteLine("Rögzített kempingfoglalások:");
foreach(string sor in File.ReadAllLines("kemping.txt"))
{
    adatok.Add(new Foglalas(sor));
}
foreach(Foglalas aktualis in adatok)
{
    Console.WriteLine(aktualis);
}
int telj = adatok.Sum(x => x.FizetendoOsszeg());
Console.WriteLine($"Kemping teljes bevétele: {telj} Ft");
int fok = adatok.Sum(x => x.GyerekFo + x.FelnottFo);
double atlag = adatok.Average(a=>a.EjszakaSzama);
Foglalas leg = adatok.MaxBy(x => x.FizetendoOsszeg());
Console.WriteLine($"Összes vendég létszáma: {fok} fő");
Console.WriteLine($"Átlagos tartózkodási idő: {atlag:f0} éjszaka");
Console.WriteLine($"Legtöbbet fizető vendég: {leg.VendegNev} ({leg.FizetendoOsszeg()} Ft)");
int ff = adatok.Count(x=>x.ParcellaTipus=="KOMFORT" &&x.GyerekFo>0);
Console.WriteLine($"Gyerekes KOMFORT foglalások száma: {ff} db");

Console.WriteLine("\nKedvezményre jogosult vendégek (legalább 5 éjszaka):");

var kedvezmenyesek = adatok.Where(x => x.EjszakaSzama >= 5);

foreach (Foglalas f in kedvezmenyesek)
{
    Console.WriteLine($"{f.VendegNev} ({f.EjszakaSzama} éjszaka)");
}

