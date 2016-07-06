using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Gra
{
    public class Gracz
    {
        public int x;//
        public int y; //wspolrzedne gracza

        public Gracz(int X,int Y)
        {
            x = X;
            y = Y;

        }


        public void Polnoc(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste)
                gracz.y--;
         }

        public void Poludnie(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste)
                gracz.y++;
        }
        public void Wschod(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste)
                gracz.x++;
        }
        public void Zachod(Pole pole, Gracz gracz)
        {
            if (pole.rodzaj == Pole.Rodzaj.Puste)
                gracz.x--;
        }
        //public void WypisywanieWspolrzednych(Gracz gracz)
        //{
        //    textBox.Text = textBox.Text + gracz.x.ToString() + " , " + gracz.y.ToString() + "\n";
        //}


    }
}
