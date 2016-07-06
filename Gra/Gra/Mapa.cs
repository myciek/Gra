using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Gra
{
    public class Mapa//jak nazwa wskazuje, po niej porusza sie gracz
    {
        public int wysokoscMapy { get; private set; }//okreslaja wymiary mapy
        public int szerokoscMapy { get; private set; }//
        public Pole[,] mapa;

        public Mapa(int wyskosc, int szerokosc)
        {
            wysokoscMapy = wyskosc;
            szerokoscMapy = szerokosc;



        }
        public void TworzenieMapy()
        {
            mapa = new Pole[wysokoscMapy, szerokoscMapy];
            for (int i = 0; i < wysokoscMapy; i++)
            {
                for (int j = 0; j < szerokoscMapy; j++)
                {
                    mapa[i, j] = new Pole(i, j);
                }


            }
        }
        public void ZapisMapy(string nazwa)
        {
            FileStream plik = new FileStream(nazwa, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter zapis = new StreamWriter(plik);
            for (int i = 0; i < wysokoscMapy; i++)
            {
                for (int j = 0; j < szerokoscMapy; j++)
                {
                    zapis.WriteLine(mapa[i, j].x + " " + mapa[i, j].y + " " + mapa[i, j].rodzaj);
                }

            }

            zapis.Close();

        }

        public void WczytywanieMapy(string nazwa)
        {
            FileStream plik = new FileStream(nazwa, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader wczytywanie = new StreamReader(plik);
            mapa = new Pole[wysokoscMapy, szerokoscMapy];
            string wczytane;
            while ((wczytane = wczytywanie.ReadLine()) != null)
            {
                string[] dane = wczytane.Split(' ');
                if (dane.Count() >= 3)
                {
                    int x = int.Parse(dane[0]);
                    int y = int.Parse(dane[1]);
                    mapa[x, y] = new Pole((x), (y));
                    if (dane[2] == "Puste")
                        mapa[(x), (y)].rodzaj = Pole.Rodzaj.Puste;
                    else
                          if (dane[2] == "Sciana")
                        mapa[(x), (y)].rodzaj = Pole.Rodzaj.Sciana;
                    else
                          if (dane[2] == "Przedmiot")
                        mapa[(x), (y)].rodzaj = Pole.Rodzaj.Przedmiot;
                    else
                          if (dane[2] == "Drzwi")
                        mapa[(x), (y)].rodzaj = Pole.Rodzaj.Drzwi;
                }
            }
            wczytywanie.Close();

        }

    }
}
