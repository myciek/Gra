using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Drzwi : Pole//potrzebny jest klucz, zeby przez nie przejsc
    {
        public int zamek;//potrzebne do sprawdzenia czy klucz pasuje do drzwi
        public Drzwi(int X, int Y, int Zamek): base(X,Y,Zamek)
        {
            zamek = Zamek;
            rodzaj = Rodzaj.Drzwi;
        }
    }
}
