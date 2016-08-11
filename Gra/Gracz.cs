using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Gra
{
    public class Gracz
    {
        public int x;//
        public int y; //wspolrzedne gracza
        public int poziom;//okresla do ktorego poziomu dotarl gracz
        public bool koniecGry;//
        public List<Przedmiot> ekwipunek;//sa w nim przechwywane dane na temat przedmiotow jakie posiada gracz
        public int iloscPrzedmiotow;//okresla ile przedmiotow posiada gracz

        public Gracz(int X, int Y, int LVL)
        {
            x = X;
            y = Y;
            poziom = LVL;
            koniecGry = false;
            iloscPrzedmiotow = 0;
            ekwipunek = new List<Przedmiot>();
        }


        public void Polnoc(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste || pole.rodzaj == Pole.Rodzaj.Przedmiot)
                gracz.y--;
        }

        public void Poludnie(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste || pole.rodzaj == Pole.Rodzaj.Przedmiot)
                gracz.y++;
        }
        public void Wschod(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste || pole.rodzaj == Pole.Rodzaj.Przedmiot)
                gracz.x++;
        }
        public void Zachod(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste || pole.rodzaj == Pole.Rodzaj.Przedmiot)
                gracz.x--;
        }

        public void Zapis()
        {
            FileStream plik = new FileStream("Gracz.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter zapis = new StreamWriter(plik);
            zapis.WriteLine(x.ToString() + "," + y.ToString() + "," + poziom.ToString());
            foreach (Przedmiot przedmiot in ekwipunek)
            {
                zapis.WriteLine(przedmiot.id.ToString());
            }
            zapis.Close();

        }

        public void Wczytaj(ref Mapa mapa)
        {
            if (File.Exists("Gracz.txt") == true)
            {
                FileStream plik = new FileStream("Gracz.txt", FileMode.Open, FileAccess.Read);
                mapa.bladWczytywania = false;
                StreamReader wczytywanie = new StreamReader(plik);
                string wczytane = wczytywanie.ReadLine();
                string[] dane = wczytane.Split(',');
                int x, y, poziom;
                if (int.TryParse(dane[0], out x) == false || int.TryParse(dane[1], out y) == false || int.TryParse(dane[2], out poziom) == false)
                    mapa.bladWczytywania = true;
                else
                {
                    this.x = x;
                    this.y = y;
                    this.poziom = poziom;

                }
                while ((wczytane = wczytywanie.ReadLine()) != null)
                {
                    int id;
                    if (int.TryParse(wczytane, out id) == false)
                        mapa.bladWczytywania = true;
                    else
                    {
                        foreach (Przedmiot przedmiot in mapa.spisPrzedmiotow)
                        {
                            if (id == przedmiot.id)
                            {
                                ekwipunek.Add(przedmiot);
                            }

                        }

                    }


                }

            }

        }
    }
}
