namespace OdevBirGorselProgramlama.Views;

public partial class ColorPicker : ContentPage
{
	public ColorPicker()
	{
		InitializeComponent();

        redSlider.ValueChanged += renkDegistirme;
        greenSlider.ValueChanged += renkDegistirme;
        blueSlider.ValueChanged += renkDegistirme;

        randomColorButton.Clicked += rasgeleRenkClick;

        copyHexButton.Clicked += kopyalaHexKodClick;

        renkGuncelle();
    }

    private void renkDegistirme(object sender, ValueChangedEventArgs e)
    {
        if (sender == redSlider)
            redLabel.Text = $"{(int)e.NewValue}";
        else if (sender == greenSlider)
            greenLabel.Text = $"{(int)e.NewValue}";
        else if (sender == blueSlider)
            blueLabel.Text = $"{(int)e.NewValue}";

        renkGuncelle();
    }

    private void renkGuncelle()
    {
        Color renk = Color.FromRgb((int)redSlider.Value, (int)greenSlider.Value, (int)blueSlider.Value);

        colorPreview.Color = renk;

        string hexCode = $"#{(int)redSlider.Value:X2}{(int)greenSlider.Value:X2}{(int)blueSlider.Value:X2}";
        hexLabel.Text = $"Hex Code: {hexCode}";
    }

    private void rasgeleRenkClick(object sender, EventArgs e)
    {
        Random random = new Random();
        redSlider.Value = random.Next(256);
        greenSlider.Value = random.Next(256);
        blueSlider.Value = random.Next(256);

        renkGuncelle();
    }

    private void kopyalaHexKodClick(object sender, EventArgs e)
    {
        string hexCode = hexLabel.Text.Replace("Hex Code: ", "");
        Clipboard.SetTextAsync(hexCode);
    }
}