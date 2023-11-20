namespace OdevBirGorselProgramlama.Views;

public partial class BodyIndex : ContentPage
{
	public BodyIndex()
	{
		InitializeComponent();

        weightSlider.ValueChanged += kiloSliderChange;
        heightSlider.ValueChanged += boySliderChange;
    }

    private void kiloSliderChange(object sender, ValueChangedEventArgs e)
    {
        double weightValue = e.NewValue;
        weightLabel.Text = $"{weightValue:F1} kg";
    }

    private void boySliderChange(object sender, ValueChangedEventArgs e)
    {
        double heightValue = e.NewValue;
        heightLabel.Text = $"{heightValue:F1} cm";
    }

    private void hesaplaClick(object sender, EventArgs e)
    {
        double weight = weightSlider.Value;
        double height = heightSlider.Value / 100;

        double indeks = IndeksHesapla(weight, height);

        resultLabel.Text = $"İndeks : {indeks:F2} - {IndeksGetir(indeks)}";
    }

    private double IndeksHesapla(double weight, double height)
    {
        return weight / (height * height);
    }

    private string IndeksGetir(double bmi)
    {
        if (bmi < 16)
            return "İleri düzeyde zayıf";
        else if (bmi < 16.99)
            return "Orta düzeyde zayıf";
        else if (bmi < 18.49)
            return "Hafif düzeyde zayıf";
        else if (bmi < 24.9)
            return "Normal kilolu";
        else if (bmi < 29.99)
            return "Hafif şişman / Fazla kilolu";
        else if (bmi < 34.99)
            return "1. derecede obez";
        else if (bmi < 39.99)
            return "2. derecede obez";
        else
            return "3. derecede obez / Morbid obez";
    }
}