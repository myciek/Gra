using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
   public class Pole//komorka, sklada sie z nich mapa

   {
      public int x { get; private set; }//
      public int y { get; private set; }//wspolrzedne komorek

      public enum Rodzaj
       {
           Puste,
           Sciana,
           Przedmiot,
           Drzwi
       };//okresla co znajduje sie na polu
       public Rodzaj rodzaj;
       public Pole(int X,int Y)
       {
           x = X;
           y = Y;
        rodzaj = Rodzaj.Puste;
       }
   }
}
