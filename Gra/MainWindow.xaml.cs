using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Gracz Player = new Gracz(3, 3);
        Mapa mapa = new Mapa(10, 10);
        

      

        public MainWindow()
        {
            InitializeComponent();
            textBox.Text = Player.x.ToString() + " , "+ Player.y.ToString();
            mapa.TworzenieMapy();


        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }








        private void EButton_Click(object sender, RoutedEventArgs e)
        {
            if (Player.x < (mapa.szerokoscMapy-1))
            { 

                int polex = Player.x + 1;
                int poley = Player.y;
                Pole pole = mapa.mapa[polex, poley];
                Player.Wschod(pole, Player);
                textBox.Text = Player.x.ToString() + " , " + Player.y.ToString();
            }
        }

     
        
        private void WButton_Click(object sender, RoutedEventArgs e)
        {
            if (Player.x > 0)
            {
                int polex = Player.x - 1;
                int poley = Player.y;
                Pole pole = mapa.mapa[polex, poley];
                Player.Zachod(pole, Player);
                textBox.Text = Player.x.ToString() + " , " + Player.y.ToString();
            }
        }

        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            if (Player.y <( mapa.wysokoscMapy - 1))
            {
                int polex = Player.x;
                int poley = Player.y + 1;
                Pole pole = mapa.mapa[polex, poley];
                Player.Poludnie(pole, Player);
                textBox.Text = Player.x.ToString() + " , " + Player.y.ToString();
            }
        }

        private void NButtton_Click(object sender, RoutedEventArgs e)
        {
            if (Player.y > 0)
            {
                int polex = Player.x;
                int poley = Player.y - 1;
                Pole pole = mapa.mapa[polex, poley];
                Player.Polnoc(pole, Player);
                textBox.Text = Player.x.ToString() + " , " + Player.y.ToString();
            }
        }
    }
}
