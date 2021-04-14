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
            int MapaX = 1000;
            int MapaY = 1000;
            int[,] Mapa = new int[MapaX, MapaY];
            const int PocetRyb = 100000;
            int Ryba = 1;
            Random rybaPozice = new Random();
            int rX, rY;
            for (int x = 0; x < PocetRyb; x++)
            {
                rX = rybaPozice.Next(0, MapaX);
                rY = rybaPozice.Next(0, MapaY);
                if (Mapa[rX, rY] == Ryba)
                {
                    while (Mapa[rX, rY] == Ryba)
                    {
                        rX = rybaPozice.Next(0, MapaX);
                        rY = rybaPozice.Next(0, MapaY);
                        if (Mapa[rX, rY] != Ryba)
                        {
                            Mapa[rX, rY] = Ryba;
                            break;
                        }
                    }
                }
                else Mapa[rX, rY] = Ryba;
            }
            //VypisPole(Mapa);
            Loviste(Mapa, 10, 10);
            MaximalniLoviste(Mapa, 30, 30);
        }
        public static void VypisPole(int[,] Pole)
        {
            int poleX = Pole.GetLength(0);
            int poleY = Pole.GetLength(1);
            for (int x = 0; x < poleX; x++)
            {
                for (int y = 0; y < poleY; y++)
                {
                    Console.Write($"{Pole[x, y]} ");
                }
            }
        }
        public static void Loviste(int[,] Pole, int delkaX, int delkaY) 
        {
            Random nc = new Random();
            int poleX = Pole.GetLength(0);
            int poleY = Pole.GetLength(1);
            int hraniceX = nc.Next(0, poleX - delkaX);
            int hraniceY = nc.Next(0, poleY - delkaY);
            if (poleX < delkaX || poleY < delkaY)
                Console.WriteLine("CHYBA");
            for (int x = hraniceX; x < hraniceX + delkaX; x++)
            {
                for (int y = hraniceY; y < hraniceY + delkaY; y++)
                {
                    if (Pole[x, y] == 1)
                        Console.WriteLine($"Ryba na pozici {y + 1}:{x + 1}");
                }
            }
        }
        public static void MaximalniLoviste(int[,] Pole, int delkaX, int delkaY) 
        {
            int poziceX = 0;
            int poziceY = 0;
            int soucetRyb = 0;
            int mezikrok;
            int vysledneRyby = 0;
            int poleX = Pole.GetLength(0);
            int poleY = Pole.GetLength(1);
            if (poleX < delkaX || poleY < delkaY)
                Console.WriteLine("CHYBA");
            for (int celkoveX = 0; celkoveX < poleX - delkaX; celkoveX++)
            {
                for (int celkoveY = 0; celkoveY < poleY - delkaY; celkoveY++)
                {
                    for (int x = 0; x < delkaX; x++)
                    {
                        for (int y = 0; y < delkaY; y++)
                        {
                            if (Pole[x + celkoveX, y + celkoveY] == 1)
                                soucetRyb++;
                        }
                    }
                    mezikrok = soucetRyb;
                    soucetRyb = 0;
                    if (mezikrok > vysledneRyby)
                    {
                        vysledneRyby = mezikrok;
                        poziceX = celkoveX;
                        poziceY = celkoveY;
                    }
                }
            }
            Console.WriteLine($"{vysledneRyby} ryb, levý horní roh je na pozici {poziceY}:{poziceX}, pravý dolní je na pozici {poziceY + delkaY - 1}:{poziceX + delkaX - 1}");
        }
    }
}
