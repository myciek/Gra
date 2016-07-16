using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
   public class Pole_Z_Przedmiotem : Pole//jak nazwa wskazuje, pole na ktorym mozna znalezc przedmiot
    {
        public int idPrzedmiotu { get; private set; }//wskazuje jaki przedmiot lezy na danym polu

        public Pole_Z_Przedmiotem(int ID,int X,int Y):base( X,  Y)
        {
            idPrzedmiotu = ID;
            rodzaj = Rodzaj.Przedmiot;
        }
       


    }
}
