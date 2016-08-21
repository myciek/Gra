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
        public string opis;//opis wyświetlający się po zaznaczeniu i kliknięciu look
        public string opisziemia;//opis wyświetlający się po użyciu look na polu z przedmiotem.
        public int id;
        public int x;//okreslaja miejsce w ktorym powinno sie uzyc przedmiotu
        public int y;//
        public bool newitem;//określa czy po użyciu przedmiotu dostaje się nowy przedmiot
        public int xsciany;//
        public int ysciany;//współrzędne ściany, która się zmienia w puste po prawidłowym użyciu przedmiotu

        public Przedmiot (string name, string desc, string descground, int Id,int X,int Y,bool nowyprzedmiot, int xwall, int ywall)
        {
            nazwa = name;
            opis = desc;
            opisziemia = descground;
            id = Id;
            x = X;
            y = Y;
            nowyprzedmiot = newitem;
            xwall = xsciany;
            ywall = ysciany;
        }
    }
}
