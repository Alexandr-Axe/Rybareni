using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rybareni
{
    class Program
    {
        static void Main()
        {
            Rybarime Santiago = new Rybarime(100, 100, 100_000);
            Santiago.RandomFishArray();
            Santiago.BestFishArray();
        }
        
    }
    public class Rybarime
    {
        public int VyskaRybnika { get; set; }
        public int SirkaRybnika { get; set; }
        public double PocetRyb { get; set; }
        public double[,] Rybnik { get; set; }
        public Rybarime(int vyskaRybnika, int sirkaRybnika, double pocetRyb) 
        {
            VyskaRybnika = vyskaRybnika;
            SirkaRybnika = sirkaRybnika;
            PocetRyb = pocetRyb;
            Rybnik = new double[VyskaRybnika, SirkaRybnika];
        }
        double hodnotaPole = 0d;
        readonly Random nc = new Random();
        double[,] CreateFishArray()
        {
            for (int x = 0; x < SirkaRybnika; x++)
            {
                for (int y = 0; y < SirkaRybnika; y++)
                {
                    Rybnik[x, y] = 1 - hodnotaPole + nc.NextDouble();//TADY JE CHYBA -> NEUMÍM GENEROVAT POMĚR VE ČTVERCÍCH, PROTO MÁM MILIONOVÝ POČTY RYB
                    hodnotaPole += Rybnik[x, y];
                }
            }
            PocetRyb *= hodnotaPole;
            for (int x = 0; x < VyskaRybnika; x++)
            {
                for (int y = 0; y < SirkaRybnika; y++)
                {
                    Rybnik[x, y] *= PocetRyb;
                }
            }
            return Rybnik;
        }
        public void RandomFishArray()
        {
            CreateFishArray();
            Console.WriteLine(Convert.ToInt32((Rybnik[nc.Next(0, 101), nc.Next(0, 101)]) / hodnotaPole));
        }
        public void BestFishArray()
        {
            CreateFishArray();
            double soucetCtvercu = 0d;
            double mezikrok;
            double vysledneRyby = 0d;
            string vypisovani = string.Empty;
            for (int x = 0; x < VyskaRybnika - 3; x++)
            {
                for (int y = 0; y < SirkaRybnika - 3; y++)
                {
                    soucetCtvercu += Rybnik[x, y];
                    soucetCtvercu += Rybnik[x + 1, y];
                    soucetCtvercu += Rybnik[x + 2, y];
                    soucetCtvercu += Rybnik[x, y + 1];
                    soucetCtvercu += Rybnik[x, y + 2];
                    soucetCtvercu += Rybnik[x + 1, y + 1];
                    soucetCtvercu += Rybnik[x + 1, y + 2];
                    soucetCtvercu += Rybnik[x + 2, y + 1];
                    soucetCtvercu += Rybnik[x + 2, y + 2];
                    mezikrok = soucetCtvercu / hodnotaPole;
                    soucetCtvercu = 0d;
                    if (mezikrok > vysledneRyby)
                    {
                        vysledneRyby = mezikrok;
                        vypisovani = $"{x}:{y} / {x + 2}:{y + 2} -> {vysledneRyby} ryb";
                    }
                }
            }
            Console.WriteLine(vypisovani);
        }
    }
}
