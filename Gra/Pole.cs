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
        public int idPrzedmiotu;//0 dla pustego pola, dla przedmiotow numer
        Przedmiot przedmiot;
        
        public enum Rodzaj
        {
            Puste,
            Sciana,
            Przedmiot,
            Drzwi
        };//okresla co znajduje sie na polu
        public Rodzaj rodzaj;
        public Pole(int X, int Y, int ID)
        {
            x = X;
            y = Y;
            if (ID == 0)
            {
                rodzaj = Rodzaj.Puste;
                przedmiot = null;
            }
            else
            idPrzedmiotu = ID;
            przedmiot.id = ID;
        }
    }
}