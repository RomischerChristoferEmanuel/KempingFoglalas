using System;

namespace KempingFoglalas
{
    public class Foglalas
    {
        public string VendegNev { get; set; }
        public string ParcellaTipus { get; set; }
        public int EjszakaSzama { get; set; }
        public int FelnottFo { get; set; }
        public int GyerekFo { get; set; }

        public Foglalas(string sor)
        {
            string[] darabol = sor.Split(';');
            VendegNev = darabol[0];
            ParcellaTipus = darabol[1];
            EjszakaSzama = int.Parse(darabol[2]);
            FelnottFo = int.Parse(darabol[3]);
            GyerekFo = int.Parse(darabol[4]);
        }

        public int FizetendoOsszeg()
        {
            int parcellaDij = 0;
            if (ParcellaTipus == "ALAP")
            {
                parcellaDij = 6000 * EjszakaSzama;
            }
            else if (ParcellaTipus == "KOMFORT")
            {
                parcellaDij = 9500 * EjszakaSzama;
            }

          
            int szemelyDij = (500 * FelnottFo + 1500 * GyerekFo) * EjszakaSzama;

            double vegosszeg = parcellaDij + szemelyDij;

            if (FelnottFo + GyerekFo > 5)
            {
                vegosszeg *= 0.90;
            }

            return (int)Math.Round(vegosszeg);
        }

        public override string ToString()
        {
            return $"{VendegNev} ({ParcellaTipus}) - {EjszakaSzama} éjszaka, Fizetendő: {FizetendoOsszeg()} Ft";
        }
    }
}