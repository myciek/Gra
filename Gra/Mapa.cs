﻿using System;
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
        public bool bladWczytywania; //sluzy do poinformowania uzykownika, ze dane ktore chce wczytac sa bledne
        public List<string> tekst = new List<string>();//przechowuje dane ktore maja byc wyswietlane uzytkownikowi
        public string wypisywanie;//jest to tekst ktory uzywtkownik widzi na ekranie
        public List<Przedmiot> spisPrzedmiotow;//przechowuje wszystkie przedmioty
        public List<Drzwi> spisDrzwi;//przechowuje drzwi
        public int koniecX { get; private set; }//wspolrzedne do ktorych gracz musi sie dostac, zeby dostac sie na kolejny poziom
        public int koniecY { get; private set; }//
        public int numerMapy;//okresla ktora mape wczytac
        public bool wczytywanie=false;//okresla czy gra zostala wczytana
        public int nrZapisu;//okresla z ktorego pliku wczytywac/zapisywac gre
        public string[] tekstyPustePole = new string[] { "Nic tu nie ma.", "Nie znajdujesz niczego.", "Widzisz pustą podłogę." }; //zbior tekstow, ktore moga wyswietlic sie gdy patrzysz na puste pole(zeby nie bylo nudno!)
        public string[] tekstyPolePrzedmiot = new string[] { "Wydaje ci sie, ze dostrzegasz cos w ciemnosci.", "Pomimo wszechobecnego mroku udalo ci sie cos znalezc.", "Po omacku dotarles do jakiegos przedmiotu." };//zbiór tekstów które wyświetlają się po wejściu na pole z przedmiotem
        public Mapa(int wyskosc, int szerokosc,int x, int y)
        {
            wysokoscMapy = wyskosc;
            szerokoscMapy = szerokosc;
            koniecX = x;
            koniecY = y;          
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
        public void ZapisMapy()//zapis mapy do pliku
        {
            FileStream plik = new FileStream("Mapa" + numerMapy + "Save" + nrZapisu + ".txt", FileMode.OpenOrCreate, FileAccess.Write);
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

        public void WczytywanieMapy(Gracz Player)//wczytuje mape z pliku
        {
            if (Player.poziom == 5)
            {
                Player.koniecGry = true;
            }

            else
            numerMapy = Player.poziom;
            {
                FileStream plik;
                if (File.Exists("Mapa" + numerMapy + "Save" + nrZapisu + ".txt") == true)
                {
                     plik = new FileStream("Mapa" + numerMapy + "Save" + nrZapisu + ".txt", FileMode.Open, FileAccess.Read);
                }
                else
                {
                     plik = new FileStream("Mapa" + numerMapy + ".txt", FileMode.Open, FileAccess.Read);
                }
                    
                    StreamReader wczytywanie = new StreamReader(plik);
                    mapa = new Pole[wysokoscMapy, szerokoscMapy];
                    string wczytane;
                    while ((wczytane = wczytywanie.ReadLine()) != null)
                    {
                        string[] dane = wczytane.Split(' ');
                        if (dane.Count() >= 4)
                        {
                            int x, y, id = 0;

                            if (int.TryParse(dane[0], out x) == false || int.TryParse(dane[1], out y) == false || int.TryParse(dane[3], out id) == false)
                                bladWczytywania = true;
                            else
                            {

                                if (dane[2] == "Puste")
                                { 
                                    mapa[x, y] = new Pole(x, y, 0);
                                mapa[x, y].rodzaj = Pole.Rodzaj.Puste;
                                }
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
                    tekst.Add("Wczytano Poziom " + Player.poziom + ". \n");
                    wczytywanie.Close();
              }
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

        public void WczytywaniePrzedmiotow()//wczytuje przedmioty,sa zapisane w pilku
        {
            if (File.Exists("Przedmioty.txt") == true)
            {
                FileStream plik = new FileStream("Przedmioty.txt", FileMode.Open, FileAccess.Read);
                bladWczytywania = false;
                StreamReader wczytywanie = new StreamReader(plik);
                string wczytane;
                spisPrzedmiotow = new List<Przedmiot>();

                while ((wczytane = wczytywanie.ReadLine()) != null)
                {
                    string[] dane = wczytane.Split(';');
                    if (dane.Count() >= 10)
                    {

                        int id, x, y, xsciany, ysciany;
                        bool newitem;
                        if (int.TryParse(dane[3], out id) == false || int.TryParse(dane[4], out x) == false || int.TryParse(dane[5], out y) == false || bool.TryParse(dane[6], out newitem) == false || int.TryParse(dane[7], out xsciany) == false || int.TryParse(dane[8], out ysciany) == false)
                            bladWczytywania = true;
                        else
                        {
                            spisPrzedmiotow.Add(new Przedmiot(dane[0], dane[1], dane[2], id, x, y, newitem, xsciany, ysciany, dane[9]));
                        }
                    }
                }
            }
            else
            bladWczytywania = true;
        }

        public void WczytywanieDrzwi()//wczytuje opisy drzwi
        {
            if (File.Exists("Drzwi.txt") == true)
            {
                FileStream plik = new FileStream("Drzwi.txt", FileMode.Open, FileAccess.Read);
                bladWczytywania = false;
                StreamReader wczytywanie = new StreamReader(plik);
                string wczytane;
                spisDrzwi = new List<Drzwi>();

                while ((wczytane = wczytywanie.ReadLine()) != null)
                {
                    string[] dane = wczytane.Split(';');
                    if (dane.Count() >= 2)
                    {
                        int id;
                        if (int.TryParse(dane[1], out id) == false)
                            bladWczytywania = true;
                        else
                        {
                            spisDrzwi.Add(new Drzwi(dane[0], id));
                        }
                    }
                }
            }
            else
            bladWczytywania = true;
        }

        public void KonczeniePoziomu(ref Gracz Player)
        {
             
           if(Player.x==koniecX && Player.y==koniecY)
            {
                Player.poziom++;
                
                switch(Player.poziom)
                {
                    case 0:
                        {
                            break;
                        }

                    case 1:
                        {
                            koniecX = 11;
                            koniecY = 24;
                            Player.x = 0;
                            Player.y = 10;
                            break;
                        }
                    case 2:
                        {
                            koniecX = 25;
                            koniecY = 5;
                            Player.x = 0;
                            Player.y = 5;
                            break;
                        }
                    case 3:
                        {
                            koniecX = 26;
                            koniecY = 13;
                            Player.x = 26;
                            Player.y = 0;
                            break;
                        }
                    case 4:
                        {
                            koniecX = 26;
                            koniecY = 13;
                            Player.x = 0;
                            Player.y = 4;
                            break;
                        }
                    default:
                        {
                            bladWczytywania = true;
                            break;
                        }
                }
                WczytywanieMapy(Player);
            }
            
        }
        public string LosowyTekst()
        {
            Random random = new Random();
            return tekstyPustePole[random.Next(0, tekstyPustePole.Length)];
        }

        public string TekstPrzedmiot()
        {
            Random random = new Random();
            return tekstyPolePrzedmiot[random.Next(0, tekstyPustePole.Length)];
        }

        public void PodnoszeniePrzedmiotu(Gracz Player, ref Pole pole)
        {
            
                Player.ekwipunek.Add(spisPrzedmiotow[pole.idPrzedmiotu-1]);
                tekst.Add("Podniosles " + spisPrzedmiotow[pole.idPrzedmiotu-1].nazwa + ". \n");
                pole.rodzaj = Pole.Rodzaj.Puste;
                pole.idPrzedmiotu = 0;
                Player.iloscPrzedmiotow++;           
        }

        public void OgladaniePrzedmiotu (Gracz Player, ref Pole pole)
        {
            tekst.Add("Widzisz " + spisPrzedmiotow[pole.idPrzedmiotu - 1].opisziemia + ". \n");
        }

        public void OgladanieDrzwi(Gracz Player, ref Pole pole)
        {
            tekst.Add("Widzisz " + spisDrzwi[pole.idPrzedmiotu - 1].opis + ". \n");
        }
    }
}