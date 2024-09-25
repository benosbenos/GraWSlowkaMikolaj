using GraWSlowkaMikolaj.Models;

namespace GraWSlowkaMikolaj
    
{
    public partial class MainPage : ContentPage
    {

        List<Pytanie> Pytania = [
            new Pytanie{pytanie="Ptak", odpowiedz="bird" },
            new Pytanie{pytanie="Broda", odpowiedz="beard" },
            new Pytanie{pytanie="Piwo", odpowiedz="beer" },
            new Pytanie{pytanie="samolot", odpowiedz="plane" },
            new Pytanie{pytanie="samochód", odpowiedz="car" },
            new Pytanie{pytanie="śmieszny", odpowiedz="funny" },
            new Pytanie{pytanie="czemu", odpowiedz="why" },
            new Pytanie{pytanie="wybuch", odpowiedz="explosion" },
            new Pytanie{pytanie="dom", odpowiedz="house" },
            new Pytanie{pytanie="jedzenie", odpowiedz="food" },
        ];

        int zycia = 3;

        int tlumacz = 0;

        Pytanie aktualnePytanie;

        public MainPage()
        {
            InitializeComponent();
            NastepnePytanie();
        }
        // Losuje pytanie z puli pytan
        void NastepnePytanie()
        {
            Random random = new();
            int output = random.Next(Pytania.Count - 1);

            aktualnePytanie = Pytania[output];

            Pytanie.Text = aktualnePytanie.pytanie;
        }

        //Cale "serce" gry, sprawdza odpowiedzi i zlicza punkty
        private void Button_Clicked(object sender, EventArgs e)
        {
            if (Odpowiedz.Text.ToLower().Trim() == aktualnePytanie.odpowiedz)
            {
                tlumacz++;
                Tlumacz.Text = $"Przetłumaczone: {tlumacz}";

                Odpowiedz.Text = "";

                DisplayAlert("Poprawna odpowiedz", "", "OK");

                NastepnePytanie();
            }
            else
            {
                zycia--;
                Zycia.Text = $"Zycia {zycia}";

                if (zycia <= 0)
                {
                    DisplayAlert("Koniec zyc", $"Gra zacznie sie na nowo. Przetlumaczone slowa: {tlumacz} ", "OK");
                    tlumacz = 0;
                    zycia = 3;

                    Zycia.Text = $"Zycia {zycia}";
                    Tlumacz.Text = $"Przetłumaczone: {tlumacz}";
                    Odpowiedz.Text = "";
                }

                DisplayAlert("Niepoprawna odpowiedz", "Spróbuj ponownie", "OK");

            }
        }
    }

}
