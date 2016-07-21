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
        public bool bladWczytywania { get; private set; }//sluzy do poindormowania uzykownika, ze dane ktore chce wczytac sa bledne
        public List<string> tekst = new List<string>();//przechowuje dane ktore maja byc wyswietlane uzytkownikowi
        public string wypisywanie;//jest to tekst ktory uzywtkownik widzi na ekranie
        public Mapa(int wyskosc, int szerokosc)
        {
            wysokoscMapy = wyskosc;
            szerokoscMapy = szerokosc;



        }
        public void TworzenieMapy()//tworzy nowa mape o podanych wymiarach
        {
            mapa = new Pole[wysokoscMapy, szerokoscMapy];
            for (int i = 0; i < wysokoscMapy; i++)
            {
                for (int j = 0; j < szerokoscMapy; j++)
                {
                    mapa[i, j] = new Pole(i, j, 0);
                }


            }
        }
        public void ZapisMapy(string nazwa)//zapis mapy do pliku
        {
            FileStream plik = new FileStream(nazwa, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter zapis = new StreamWriter(plik);
            for (int i = 0; i < wysokoscMapy; i++)
            {
                for (int j = 0; j < szerokoscMapy; j++)
                {
                    if (mapa[i, j].rodzaj == Pole.Rodzaj.Przedmiot || mapa[i, j].rodzaj == Pole.Rodzaj.Drzwi)
                        zapis.WriteLine(mapa[i, j].x + " " + mapa[i, j].y + " " + mapa[i, j].rodzaj + " " + mapa[i, j].idPrzedmiotu);
                    else
                        zapis.WriteLine(mapa[i, j].x + " " + mapa[i, j].y + " " + mapa[i, j].rodzaj + " 0");

                }

            }

            zapis.Close();

        }

        public void WczytywanieMapy(string nazwa)//wczytuje mape z pliku
        {


            if (File.Exists(nazwa) == true)
            {
                FileStream plik = new FileStream(nazwa, FileMode.Open, FileAccess.Read);
                bladWczytywania = false;
                StreamReader wczytywanie = new StreamReader(plik);
                mapa = new Pole[wysokoscMapy, szerokoscMapy];
                string wczytane;
                while ((wczytane = wczytywanie.ReadLine()) != null)
                {
                    string[] dane = wczytane.Split(' ');
                    if (dane.Count() >= 4)
                    {
                        int x, y, id = 0;

                        if (int.TryParse(dane[0], out x) == false || int.TryParse(dane[1], out y) == false)
                            bladWczytywania = true;
                        else
                        {

                            if (dane[2] == "Puste")
                                mapa[x, y] = new Pole(x, y, 0);
                            else
                                  if (dane[2] == "Sciana")
                            {
                                mapa[x, y] = new Pole(x, y, 0);
                                mapa[x, y].rodzaj = Pole.Rodzaj.Sciana;
                            }
                            else
                                  if (dane[2] == "Przedmiot")
                            {
                                mapa[x, y] = new Pole(x, y, id);
                                mapa[x, y].rodzaj = Pole.Rodzaj.Przedmiot;
                            }
                            else
                                  if (dane[2] == "Drzwi")
                            {
                                mapa[x, y] = new Pole(x, y, id);
                                mapa[x, y].rodzaj = Pole.Rodzaj.Drzwi;
                            }
                            else
                                bladWczytywania = true;
                        }
                    }
                }

                wczytywanie.Close();
            }
            else
                bladWczytywania = true;



        }
        public void WypisywanieTesktu()//dzieki tej metodzie informacje na ekranie "przesuwaja sie" gdy jest ich wiecej
        {
            if (tekst.Count > 10)
                tekst.RemoveAt(0);
            wypisywanie = null;
            foreach (string wyrazenie in tekst)
            {
                wypisywanie += wyrazenie;
            }
        }



    }
}