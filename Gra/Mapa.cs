using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public class Mapa//jak nazwa wskazuje, po niej porusza sie gracz
    {
       public  int wysokoscMapy { get; private set; }//okreslaja wymiary mapy
       public  int szerokoscMapy { get; private set; }//
        public Pole[,] mapa;

        public Mapa(int wyskosc,int szerokosc)
        {
            wysokoscMapy = wyskosc;
            szerokoscMapy = szerokosc;
            

            
        }
        public void TworzenieMapy()
        {
            mapa = new Pole[wysokoscMapy, szerokoscMapy];
            for (int i = 0; i < wysokoscMapy; i++)
            {
                for (int j = 0; j < szerokoscMapy; j++)
                {
                    mapa[i, j] = new Pole(i, j);
                }
                

            }
        }


    }
}
