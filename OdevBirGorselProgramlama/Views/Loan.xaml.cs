namespace OdevBirGorselProgramlama.Views;

public partial class Loan : ContentPage
{
    Entry tutarEntry, oranEntry, vadeEntry;
    Picker krediTurPicker;
    Label aylıkTaksitLabel, toplamOdemeLabel, toplamFaizLabel;

    public Loan()
	{
		InitializeComponent();

        tutarEntry = new Entry { Placeholder = "Kredi Tutarı (TL)" , 
            PlaceholderColor = Colors.Black, 
            Margin = 5 ,    
        };
        oranEntry = new Entry { Placeholder = "Faiz Oranı (%)" , PlaceholderColor = Colors.Black, Margin = 5, };
        vadeEntry = new Entry { Placeholder = "Vade (Ay)" , PlaceholderColor =  Colors.Black, Margin = 5, };

        krediTurPicker = new Picker
        {
            Title = "Kredi Türü",
            Margin = 5,
            TextColor = Colors.Black,
            Items = { "İhtiyaç Kredisi", "Konut Kredisi", "Taşıt Kredisi", "Ticari Kredi" }
        };

        aylıkTaksitLabel = new Label();
        toplamOdemeLabel = new Label();
        toplamFaizLabel = new Label();

        Button hesaplaButton = new Button
        {
            Text = "Hesapla",
            Margin =10 ,
            BackgroundColor = Colors.Orange,
            BorderColor = Colors.Yellow, BorderWidth = 2 ,
            Command = new Command(HesaplaButton_Clicked)
        };

        Content = new StackLayout
        {
            Padding = new Thickness(20),
            Children =
                {
                    tutarEntry,
                    oranEntry,
                    vadeEntry,
                    krediTurPicker,
                    hesaplaButton,
                    new Label { Text = "Aylık Taksit:", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) ,TextColor =Colors.Red , Margin = 5 ,},
                    aylıkTaksitLabel,
                    new Label { Text = "Toplam Ödeme:", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))  , TextColor =Colors.Green, Margin = 5},
                    toplamOdemeLabel,
                    new Label { Text = "Toplam Faiz:", FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label)) ,TextColor =Colors.Blue, Margin = 5},
                    toplamFaizLabel
                }
        };
    }

    private void HesaplaButton_Clicked()
    {
        if (double.TryParse(tutarEntry.Text, out double tutar) &&
            double.TryParse(oranEntry.Text, out double oran) &&
            int.TryParse(vadeEntry.Text, out int vade))
        {
            double kkdfOran = 0, bsmvOran = 0;

            switch (krediTurPicker.SelectedItem.ToString())
            {
                case "İhtiyaç Kredisi":
                    kkdfOran = 15;
                    bsmvOran = 10;
                    break;
                case "Konut Kredisi":
                    break;
                case "Taşıt Kredisi":
                    kkdfOran = 15;
                    bsmvOran = 5;
                    break;
                case "Ticari Kredi":
                    bsmvOran = 5;
                    break;
            }

            double brutFaiz = ((oran + (oran * bsmvOran / 100) + (oran * kkdfOran / 100)) / 100);
            double taksit = ((Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1)) * tutar;
            double toplamOdeme = taksit * vade;
            double toplamFaiz = toplamOdeme - tutar;

            aylıkTaksitLabel.Text = $"{Math.Round(taksit, 2)} TL";
            toplamOdemeLabel.Text = $"{Math.Round(toplamOdeme, 2)} TL";
            toplamFaizLabel.Text = $"{Math.Round(toplamFaiz, 2)} TL";
        }
        else
        {
            DisplayAlert("Hata", "Geçersiz giriş verileri!", "Tamam");
        }
    }
}