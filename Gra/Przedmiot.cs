using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Przedmiot
    {
        public string nazwa;
        public string opis;
        public string opisziemia;
        public int id;

        public Przedmiot (string name, string desc, string descground, int Id)
        {
            nazwa = name;
            opis = desc;
            opisziemia = descground;
            id = Id;

        }

        public void NaZiemi(Mapa mapa)
        {
            mapa.tekst.Add(string.Format("Twoją uwagę zwraca leżący na ziemi {0} \n", opisziemia));
            mapa.WypisywanieTesktu();
        }
    }
}
