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
using System.IO;
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
            textBox.Text = "Witaj, wczytaj mape za pomocą Load";
            NButtton.IsEnabled = false;
            SButton.IsEnabled = false;
            EButton.IsEnabled = false;
            WButton.IsEnabled = false;
            SaveButton.IsEnabled = false;
            LookButton.IsEnabled = false;
            UseButton.IsEnabled = false;
            TakeButton.IsEnabled = false;
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
                mapa.tekst.Add(Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
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
                mapa.tekst.Add(Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
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
                mapa.tekst.Add(Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
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
                mapa.tekst.Add(Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
        }

        private void LookButton_Click(object sender, RoutedEventArgs e)
        {
            int polex = Player.x;
            int poley = Player.y;
            Pole pole = mapa.mapa[polex, poley];
            if (pole.rodzaj == Pole.Rodzaj.Puste)
            {
                textBox.Text = textBox.Text + "Widzisz pustą podłogę \n";
            }

        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            mapa.ZapisMapy("MapaTestowa.txt");

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            mapa.WczytywanieMapy("MapaTestowa.txt");
            if (mapa.bladWczytywania == false)
            {
                textBox.Text = "Wczytano mape!\n";
                NButtton.IsEnabled = true;
                SButton.IsEnabled = true;
                EButton.IsEnabled = true;
                WButton.IsEnabled = true;
                SaveButton.IsEnabled = true;
                LookButton.IsEnabled = true;
                UseButton.IsEnabled = true;
                TakeButton.IsEnabled = true;
            }
            else
                textBox.Text = "Blad wczytywania! Czyzbys grzebal w pikach?";

        }
    }
}
