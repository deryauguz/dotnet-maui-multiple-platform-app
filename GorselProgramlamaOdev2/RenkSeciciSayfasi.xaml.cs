using Microsoft.Maui.Controls;
using System;
using Microsoft.Maui.Graphics;

namespace GorselProgramlamaOdev2.Views

{
    public partial class RenkSeciciSayfasi : ContentPage
    {
        private readonly Random _random = new Random();

        public RenkSeciciSayfasi()
        {
            InitializeComponent();
            RenkSlider_ValueChanged(null, null);
        }

        private void RenkSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // 1. Deðerleri Al
            int r = (int)SliderRed.Value;
            int g = (int)SliderGreen.Value;
            int b = (int)SliderBlue.Value;

            // 2. Renk Nesnesini Oluþtur
            Color yeniRenk = Color.FromRgb(r, g, b);

            // 3. Label Deðerlerini Güncelle
            LabelRed.Text = $"Kýrmýzý (Red): {r}";
            LabelGreen.Text = $"Yeþil (Green): {g}";
            LabelBlue.Text = $"Mavi (Blue): {b}";

            // 4. Hex Kodu ve Arka Planý Güncellemek için
            string renkKodu = yeniRenk.ToHex();

            ThisPage.BackgroundColor = yeniRenk;
            LabelRenkKodu.Text = renkKodu;

            // 5. Okunabilirliði Saðlamak için
            Color metinRengi = CalculateTextColor(yeniRenk);
            LabelRenkKodu.TextColor = metinRengi;
            LabelRed.TextColor = metinRengi;
            LabelGreen.TextColor = metinRengi;
            LabelBlue.TextColor = metinRengi;
        }

        private async void KopyalaButton_Clicked(object sender, EventArgs e)
        {
            string renkKodu = LabelRenkKodu.Text;
            await Clipboard.SetTextAsync(renkKodu);
            await DisplayAlert("Kopyalandý", $"Renk kodu panoya kopyalandý: {renkKodu}", "Tamam");

        }

        private void RastgeleRenkButton_Clicked(object sender, EventArgs e)
        {
            SliderRed.Value = _random.Next(256);
            SliderGreen.Value = _random.Next(256);
            SliderBlue.Value = _random.Next(256);
        }


        private Color CalculateTextColor(Color color)
        {

            double luminance = 0.2126 * color.Red + 0.7152 * color.Green + 0.0722 * color.Blue;
            return luminance > 0.5 ? Colors.Black : Colors.White;
        }
    }
}