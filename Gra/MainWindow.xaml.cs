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
        Gracz Player = new Gracz(3,1,0);
        Mapa mapa = new Mapa(31, 27,17,9); 
        public MainWindow()
        {
            
            InitializeComponent();
            textBox.Text = "Witaj,wybierz slot i wczytaj gre za pomocą Load (jesli nie zapisywales wczesniej gry na slocie, ktory wybrales, rozpoczniesz nowa gre).";
            listBox.Items.Add("Save1");
            listBox.Items.Add("Save2");
            listBox.Items.Add("Save3");
            listBox.Items.Add("Save4");
            listBox.Items.Add("Save5");
            
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
            
            if (Player.koniecGry == false)
            {
                if (Player.x < (mapa.szerokoscMapy - 1))
                {
                    int polex = Player.x + 1;
                    int poley = Player.y;
                    Pole pole = mapa.mapa[polex, poley];
                    Player.Wschod(pole, Player);
                    if (pole.rodzaj == Pole.Rodzaj.Sciana && mapa.mapa[Player.x, Player.y].rodzaj != Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add(mapa.TekstPrzedmiot() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else
                    {
                        mapa.tekst.Add("Poszedłeś na wschód. " +Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                }
                else
                {
                    mapa.tekst.Add("Napotykasz ścianę \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
            }
            else
            {
                mapa.tekst.Add("GRATULACJE UKONCZYLES GRE!!! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            mapa.KonczeniePoziomu(ref Player);
            mapa.WypisywanieTesktu();
            textBox.Text = mapa.wypisywanie;
        }

        private void WButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Player.koniecGry == false)
            {
                if (Player.x > 0)
                {
                    int polex = Player.x - 1;
                    int poley = Player.y;
                    Pole pole = mapa.mapa[polex, poley];
                    Player.Zachod(pole, Player);
                    if (pole.rodzaj == Pole.Rodzaj.Sciana && mapa.mapa[Player.x, Player.y].rodzaj != Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add(mapa.TekstPrzedmiot() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else
                    {
                        mapa.tekst.Add("Poszedłeś na zachód. " + Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                }
                else
                {
                    mapa.tekst.Add("Napotykasz ścianę \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
            }
            else
            {
                mapa.tekst.Add("GRATULACJE UKONCZYLES GRE!!! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            mapa.KonczeniePoziomu(ref Player);
            mapa.WypisywanieTesktu();
            textBox.Text = mapa.wypisywanie;
        }

        private void SButton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Player.koniecGry == false)
            {
                if (Player.y < (mapa.wysokoscMapy - 1))
                {
                    int polex = Player.x;
                    int poley = Player.y + 1;
                    Pole pole = mapa.mapa[polex, poley];
                    Player.Poludnie(pole, Player);
                    if (pole.rodzaj == Pole.Rodzaj.Sciana && mapa.mapa[Player.x, Player.y].rodzaj != Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add(mapa.TekstPrzedmiot() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else
                    {
                        mapa.tekst.Add("Poszedłeś na południe. " + Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                }
                else
                {
                    mapa.tekst.Add("Napotykasz ścianę \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
            }
            else
            {
                mapa.tekst.Add("GRATULACJE UKONCZYLES GRE!!! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            mapa.KonczeniePoziomu(ref Player);
            mapa.WypisywanieTesktu();
            textBox.Text = mapa.wypisywanie;
            
        }

        private void NButtton_Click(object sender, RoutedEventArgs e)
        {
            
            if (Player.koniecGry == false)
            {
                if (Player.y > 0)
                {
                    int polex = Player.x;
                    int poley = Player.y - 1;
                    Pole pole = mapa.mapa[polex, poley];
                    Player.Polnoc(pole, Player);
                    if (pole.rodzaj == Pole.Rodzaj.Sciana && mapa.mapa[Player.x,Player.y].rodzaj != Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi)
                    {
                        mapa.tekst.Add(mapa.TekstPrzedmiot() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else
                    {
                        mapa.tekst.Add("Poszedłeś na północ. " + Player.x.ToString() + " , " + Player.y.ToString() + "\n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                }
                else
                {
                    mapa.tekst.Add("Napotykasz ścianę \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
            }
            else
            {
                mapa.tekst.Add("GRATULACJE UKONCZYLES GRE!!! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            mapa.KonczeniePoziomu(ref Player);
            mapa.WypisywanieTesktu();
            textBox.Text = mapa.wypisywanie;
        }

        private void LookButton_Click(object sender, RoutedEventArgs e)
        {
            int polex = Player.x;
            int poley = Player.y;
            Pole pole = mapa.mapa[polex, poley];
            if (listBox.SelectedItem == null)
            {
                if (pole.rodzaj == Pole.Rodzaj.Puste)
                {

                    mapa.tekst.Add(mapa.LosowyTekst() + "\n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
                else if (mapa.mapa[Player.x, Player.y].rodzaj == Pole.Rodzaj.Przedmiot)
                {
                    mapa.OgladaniePrzedmiotu(Player, ref mapa.mapa[Player.x, Player.y]);
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                    listBox.SelectedItem = null;
                }
                else if (mapa.mapa[Player.x, Player.y].rodzaj == Pole.Rodzaj.Drzwi)
                {
                    mapa.OgladanieDrzwi(Player, ref mapa.mapa[Player.x, Player.y]);
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
            }
            else
            {
                string nazwa = listBox.SelectedItem.ToString();
                Przedmiot wybranyPrzedmiot = new Przedmiot("Test", "Srest", "Tetest", 0, 0, 0, false, 0, 0, "trata");

                foreach (Przedmiot przedmiot in Player.ekwipunek)
                {
                    if (przedmiot.nazwa == nazwa)
                        wybranyPrzedmiot = przedmiot;
                }
                mapa.tekst.Add(wybranyPrzedmiot.opis + "\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
                listBox.SelectedItem = null;
            }


        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(1);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            mapa.ZapisMapy();
            Player.Zapis(mapa);

        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            if (mapa.wczytywanie == false)
            {
                if (listBox.SelectedItem != null)
                {
                    if (listBox.SelectedItem.ToString() == "Save1")
                        mapa.nrZapisu = 1;
                    else
                        if (listBox.SelectedItem.ToString() == "Save2")
                            mapa.nrZapisu = 2;
                        else
                            if (listBox.SelectedItem.ToString() == "Save3")
                                mapa.nrZapisu = 3;
                            else
                                if (listBox.SelectedItem.ToString() == "Save4")
                                    mapa.nrZapisu = 4;
                                else
                                    mapa.nrZapisu = 5;
                    listBox.Items.Clear();                                   
                    mapa.WczytywaniePrzedmiotow();
                    mapa.WczytywanieDrzwi();
                    Player.Wczytaj(ref mapa);
                    foreach (Przedmiot przedmiot in Player.ekwipunek)
                    {
                        listBox.Items.Add(przedmiot.nazwa);
                    }
                    mapa.WczytywanieMapy(Player);

                    if (Player.koniecGry == true)
                    {
                        textBox.Text = "GRATULACJE UKONCZYLES GRE!!! \n";
                        NButtton.IsEnabled = true;
                        SButton.IsEnabled = true;
                        EButton.IsEnabled = true;
                        WButton.IsEnabled = true;
                    }

                    else
                    {
                        if (mapa.bladWczytywania == false)
                        {
                            textBox.Text = "Wczytano Poziom " + Player.poziom + ".";
                            NButtton.IsEnabled = true;
                            SButton.IsEnabled = true;
                            EButton.IsEnabled = true;
                            WButton.IsEnabled = true;
                            SaveButton.IsEnabled = true;
                            LookButton.IsEnabled = true;
                            UseButton.IsEnabled = true;
                            TakeButton.IsEnabled = true;
                            mapa.wczytywanie = true;
                        }
                        else
                            textBox.Text = "Blad wczytywania! Czyzbys grzebal w plikach?";

                    }
                }
                else
                {
                    textBox.Text = "Wybierz slot!";
                }
            }
            else
            {
                textBox.Text = "Juz wczytano. Jesli chcesz wczytac wczesniejsze postepy uruchom gre ponownie. \n";
            }
        }
        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TakeButton_Click(object sender, RoutedEventArgs e)
        {
            if (mapa.mapa[Player.x, Player.y].rodzaj == Pole.Rodzaj.Przedmiot)
            {
                mapa.PodnoszeniePrzedmiotu(Player, ref mapa.mapa[Player.x, Player.y]);
                listBox.Items.Add(Player.ekwipunek[Player.iloscPrzedmiotow - 1].nazwa);
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            else
            {
                mapa.tekst.Add("Nie masz czego tu podnieść.\n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }

        }

        private void UseButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem == null)
            {
                mapa.tekst.Add("Powietrza nie użyjesz do czego innego niz oddychanie! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            else {
                string nazwa = listBox.SelectedItem.ToString();
                Przedmiot wybranyPrzedmiot= new Przedmiot("Test","a","b",3,0,0,false, 0, 0, "tratata");
                int i = 0;
                int nrprzedmiotu = 0;
                foreach (Przedmiot przedmiot in Player.ekwipunek)
                {
                    i++;
                    if (nazwa == przedmiot.nazwa)
                    {
                         wybranyPrzedmiot = przedmiot;
                         nrprzedmiotu = i;
                        wybranyPrzedmiot.xsciany = przedmiot.xsciany;
                        wybranyPrzedmiot.ysciany = przedmiot.ysciany;
                    }

                }
                if(wybranyPrzedmiot.x==Player.x && wybranyPrzedmiot.y==Player.y)
                {
                    if(wybranyPrzedmiot.newitem == true)
                    {

                        Player.ekwipunek.Remove(Player.ekwipunek[nrprzedmiotu]);
                        listBox.Items.Remove(wybranyPrzedmiot.nazwa);
                        //    Player.ekwipunek.Add(spisPrzedmiotow[wybranyPrzedmiot.id+1]);
                        //    listBox.Items.Add(nowyPrzedmiot.nazwa);
                        //    mapa.tekst.Add("Uzyskales " + nowyPrzedmiot.nazwa + " /n";
                        if (wybranyPrzedmiot.id == 7)
                        {
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].rodzaj = Pole.Rodzaj.Drzwi;
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].idPrzedmiotu = 10;
                        }
                        //    mapa.WypisywanieTesktu();
                        //    textBox.Text = mapa.wypisywanie;
                    }
                    else
                    mapa.tekst.Add(wybranyPrzedmiot.uzycie + "\n");
                    mapa.mapa[wybranyPrzedmiot.xsciany, wybranyPrzedmiot.ysciany].idPrzedmiotu = 0;
                    mapa.mapa[wybranyPrzedmiot.xsciany, wybranyPrzedmiot.ysciany].rodzaj = Pole.Rodzaj.Puste;
                   
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }

                else
                {
                    mapa.tekst.Add("Sprobowales uzyc " + wybranyPrzedmiot.nazwa+ " ale nic sie nie stalo. \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
                listBox.SelectedItem = null;
            }
        }
    }
}
