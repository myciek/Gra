using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    class Przedmiot
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public string nazwa;
        public string opis;
        public string opisziemia;
        public int id;

        public Przedmiot (int X, int Y, string name, string desc, string descground, int Id)
        {
            x = X;
            y = Y;
            nazwa = name;
            desc = opis;
            descground = opisziemia;
            id = Id;

        }

        public void NaZiemi(Mapa mapa)
        {
            mapa.tekst.Add(string.Format("Twoją uwagę zwraca leżący na ziemi {0} \n", opisziemia));
            mapa.WypisywanieTesktu();
        }
    }
}
