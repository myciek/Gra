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
            textBox.Text = "Witamy w Labiryncie Lochu Naphilion. Jest to połączenie gry typu dungeon crawler z przygodową. Przemieszczanie odbywa się za pośrednictwem przycisków N,S,W,E. Za pomocą klawisza Take można podnosić znalezione przedmioty. Za pomocą klawisza Look można oglądać przedmioty po uprzednim wybraniu ich w ekwipunku (lista po prawej stronie) lub oglądać sam loch. Za pomocą klawisza Use można korzystać z przedmiotów z ekwipunku lub przełączników w lochu. Możesz także zapisać grę naciskając przycisk Save, aby nie stracić postępów po wyłączeniu gry. Jeżeli nie zapisywałeś na którymś slocie, wczytując go uruchomisz nową grę. Miłej zabawy!";
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
                    if (pole.rodzaj == Pole.Rodzaj.Sciana)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi || pole.rodzaj == Pole.Rodzaj.Przelacznik)
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
                mapa.tekst.Add("Udało ci się wydostać z podziemia, czym kończy się twoja przygoda w Labiryncie Lochu Naphillion. Gratulacje! \n");
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
                    if (pole.rodzaj == Pole.Rodzaj.Sciana)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi || pole.rodzaj == Pole.Rodzaj.Przelacznik)
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
                mapa.tekst.Add("Udało ci się wydostać z podziemia, czym kończy się twoja przygoda w Labiryncie Lochu Naphillion. Gratulacje! \n");
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
                    if (pole.rodzaj == Pole.Rodzaj.Sciana)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi || pole.rodzaj == Pole.Rodzaj.Przelacznik)
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
                mapa.tekst.Add("Udało ci się wydostać z podziemia, czym kończy się twoja przygoda w Labiryncie Lochu Naphillion. Gratulacje! \n");
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
                    if (pole.rodzaj == Pole.Rodzaj.Sciana)
                    {
                        mapa.tekst.Add("Napotykasz ścianę \n");
                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else if (pole.rodzaj == Pole.Rodzaj.Przedmiot || pole.rodzaj == Pole.Rodzaj.Drzwi || pole.rodzaj == Pole.Rodzaj.Przelacznik)
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
                mapa.tekst.Add("Udało ci się wydostać z podziemia, czym kończy się twoja przygoda w Labiryncie Lochu Naphillion. Gratulacje! \n");
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
                else if (pole.rodzaj == Pole.Rodzaj.Przelacznik)
                {
                    mapa.tekst.Add("Widzisz na ścianie przełącznik. \n");
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
                        textBox.Text = "Udało ci się wydostać z podziemia, czym kończy się twoja przygoda w Labiryncie Lochu Naphillion. Gratulacje!\n";
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
                            textBox.Text = "Błąd wczytywania! Czyżbyś grzebał w plikach?";

                    }
                }
                else
                {
                    textBox.Text = "Wybierz slot!";
                }
            }
            else
            {
                textBox.Text = "Już wczytano. Jeśli chcesz wczytać wcześniejsze postępy, uruchom grę ponownie. \n";
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
            int polex = Player.x;
            int poley = Player.y;
            Pole pole = mapa.mapa[polex, poley];
            if (listBox.SelectedItem == null && pole.rodzaj != Pole.Rodzaj.Przelacznik)
            {
                mapa.tekst.Add("Powietrza nie użyjesz do czego innego niż oddychanie! \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
            }
            else if (listBox.SelectedItem == null && pole.rodzaj == Pole.Rodzaj.Przelacznik)
            {
                mapa.tekst.Add("Pociągnąłeś za wajchę i usłyszałeś, że gdzieś musiało się otworzyć przejście \n");
                mapa.WypisywanieTesktu();
                textBox.Text = mapa.wypisywanie;
                if (pole.idPrzedmiotu == 1)
                {
                    mapa.mapa[6,17].rodzaj = Pole.Rodzaj.Puste;
                    mapa.mapa[6, 17].idPrzedmiotu = 0;
                    mapa.mapa[6, 18].rodzaj = Pole.Rodzaj.Puste;
                }
                if (pole.idPrzedmiotu == 2)
                {
                    mapa.mapa[10, 2].rodzaj = Pole.Rodzaj.Puste;
                    mapa.mapa[10, 2].idPrzedmiotu = 0;
                    mapa.mapa[11, 2].rodzaj = Pole.Rodzaj.Puste;
                }

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

                        Player.ekwipunek.Remove(Player.ekwipunek[nrprzedmiotu - 1]);
                        listBox.Items.Remove(wybranyPrzedmiot.nazwa);
                        Player.ekwipunek.Add(mapa.spisPrzedmiotow[wybranyPrzedmiot.id+1]);
                        listBox.Items.Add(mapa.spisPrzedmiotow[wybranyPrzedmiot.id + 1].nazwa);
                        mapa.tekst.Add(wybranyPrzedmiot.uzycie + "\n");
                        mapa.tekst.Add("Uzyskales " + mapa.spisPrzedmiotow[wybranyPrzedmiot.id + 1].nazwa + " \n");
                        if (wybranyPrzedmiot.id == 7)
                        {
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].rodzaj = Pole.Rodzaj.Drzwi;
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].idPrzedmiotu = 10;
                        }
                        if (wybranyPrzedmiot.id == 21)
                        {
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].rodzaj = Pole.Rodzaj.Drzwi;
                            mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].idPrzedmiotu = 22;
                        }

                        mapa.WypisywanieTesktu();
                        textBox.Text = mapa.wypisywanie;
                    }
                    else
                    mapa.tekst.Add(wybranyPrzedmiot.uzycie + "\n");
                    mapa.mapa[wybranyPrzedmiot.xsciany, wybranyPrzedmiot.ysciany].idPrzedmiotu = 0;
                    mapa.mapa[wybranyPrzedmiot.xsciany, wybranyPrzedmiot.ysciany].rodzaj = Pole.Rodzaj.Puste;
                    mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].rodzaj = Pole.Rodzaj.Puste;
                    mapa.mapa[wybranyPrzedmiot.x, wybranyPrzedmiot.y].idPrzedmiotu = 0;
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }

                else
                {
                    mapa.tekst.Add("Spróbowałeś użyć " + wybranyPrzedmiot.nazwa+ ", ale nic się nie stało. \n");
                    mapa.WypisywanieTesktu();
                    textBox.Text = mapa.wypisywanie;
                }
                listBox.SelectedItem = null;
            }
        }
    }
}
