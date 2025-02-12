using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp17
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Obraz>listaObrazow {  get; set; }=new List<Obraz>();
        public int IdObrazka { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
            string[] obrazki = File.ReadAllLines("Data.txt");
            for (int i = 0; i < obrazki.Length; i += 4)
            {
                string obrazek = obrazki[i];
                int wyswietlenia = int.Parse(obrazki[i + 1]);
                int polubienia = int.Parse(obrazki[i + 2]);
                listaObrazow.Add(new Obraz(obrazek, wyswietlenia, polubienia));
                
               

            } 
            Wyswietl(IdObrazka);

        }
        public void Wyswietl(int i)
        {
            zdj.Source=new BitmapImage(new Uri(listaObrazow[i].UrlObrazka, UriKind.Relative));
            listaObrazow[i].Wyswietl();
            liczbaWyswietlen.Text ="Liczba Wyswietlen: "+ listaObrazow[i].Wyswietlenia.ToString();
            liczbaPolubien.Text = "Liczba Polubien: " + listaObrazow[i].Polubienia.ToString();

        }
        public void Pobierz(int j)
        {
            Obraz obraz=listaObrazow [j];
            obraz.PolubZdj();
            liczbaPolubien.Text = "Liczba Polubien: " + listaObrazow[j].Polubienia.ToString();
        }
       
        private void Nastepne(object sender, RoutedEventArgs e)
        {
            IdObrazka++;
            if (IdObrazka == listaObrazow.Count)
            {
                IdObrazka = 0;
            }
            Wyswietl(IdObrazka);
           
        }

        private void Poprzednie(object sender, RoutedEventArgs e)
        {
            IdObrazka--;
            if (IdObrazka < 0) {
                IdObrazka = listaObrazow.Count() - 1;
            }
            Wyswietl(IdObrazka);
           
        }

        private void Polub(object sender, RoutedEventArgs e)
        {
            Pobierz(IdObrazka);
        }

        private void Zamknij(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("../../../Data.txt");
            for (int i = 0; i<listaObrazow.Count ; i++) {
                sw.WriteLine(listaObrazow[i].UrlObrazka);
                sw.WriteLine(listaObrazow[i].Wyswietlenia);
                sw.WriteLine(listaObrazow[i].Polubienia);
            }
            sw.Close();
            Close();
            
        }
    }
}
