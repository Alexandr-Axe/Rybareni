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
            //Santiago.BestFishArray(0, 0, 0);
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
        Random nc = new Random();
        double[,] CreateFishArray()
        {
            for (int x = 0; x < Rybnik.GetLength(1); x++)
            {
                for (int y = 0; y < Rybnik.GetLength(0); y++)
                {
                    Rybnik[x, y] = nc.NextDouble();
                    hodnotaPole += Rybnik[x, y];
                }
            }
            PocetRyb *= hodnotaPole;
            for (int x = 0; x < Rybnik.GetLength(1); x++)
            {
                for (int y = 0; y < Rybnik.GetLength(0); y++)
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
        }
    }
}
