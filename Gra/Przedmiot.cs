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
        public int x;//okreslaja miejsce w ktorym powinno sie uzyc przedmiotu
        public int y;//

        public Przedmiot (string name, string desc, string descground, int Id,int X,int Y)
        {
            nazwa = name;
            opis = desc;
            opisziemia = descground;
            id = Id;
            x = X;
            y = Y;

        }
    }
}
