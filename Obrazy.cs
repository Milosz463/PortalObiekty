using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp17
{
    public class Obraz
    {
        public string UrlObrazka;
        public int Wyswietlenia { get; set; } = 0;
        public int Polubienia;

        public Obraz(string urlObrazka, int wyswietlenia, int polubienia)
        {
            this.UrlObrazka = urlObrazka;
            this.Wyswietlenia = wyswietlenia;
            this.Polubienia = polubienia;
        }

        public void PolubZdj()
        {
            Polubienia++;
        }
        public void Wyswietl()
        {
            Wyswietlenia++;
        }
    }
}
