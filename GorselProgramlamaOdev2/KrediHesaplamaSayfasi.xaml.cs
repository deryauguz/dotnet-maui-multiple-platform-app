using Microsoft.Maui.Controls;
using System;
using System.Security.Cryptography;

namespace GorselProgramlamaOdev2.Views

{
    public partial class KrediHesaplamaSayfasi : ContentPage
    {
        public KrediHesaplamaSayfasi()
        {
            InitializeComponent();
            sliderVade.Value = 12;
            lblVade.Text = $"{(int)sliderVade.Value} Ay";
        }

        private void SliderVade_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int vade = (int)Math.Round(e.NewValue);
            lblVade.Text = $"{vade} Ay";
        }

        private async void ButtonHesapla_Clicked(object sender, EventArgs e)
        {
            lblSonuc.Text = "";

            if (pickerKrediTuru.SelectedItem == null)
            {
                await DisplayAlert("Uyarý", "Lütfen kredi türünü seçiniz.", "Tamam");
                return;
            }

            if (string.IsNullOrWhiteSpace(entryTutar.Text))
            {
                await DisplayAlert("Uyarý", "Lütfen kredi tutarýný giriniz.", "Tamam");
                return;
            }

            if (string.IsNullOrWhiteSpace(entryFaiz.Text))
            {
                await DisplayAlert("Uyarý", "Lütfen faiz oranýný giriniz.", "Tamam");
                return;
            }

            if (!double.TryParse(entryTutar.Text, out double tutar) || tutar <= 0)
            {
                await DisplayAlert("Uyarý", "Geçerli bir kredi tutarý giriniz.", "Tamam");
                return;
            }

            if (!double.TryParse(entryFaiz.Text, out double oran) || oran <= 0)
            {
                await DisplayAlert("Uyarý", "Geçerli bir faiz oraný giriniz.", "Tamam");
                return;
            }

            int vade = (int)sliderVade.Value;
            if (vade < 1)
            {
                lblSonuc.Text = "Vade en az 1 ay olmalýdýr.";
                return;
            }

            double KKDF = 0, BSMV = 0;
            switch (pickerKrediTuru.SelectedItem.ToString())
            {
                case "Ýhtiyaç Kredisi":
                    KKDF = 0.15;
                    BSMV = 0.10;
                    break;
                case "Konut Kredisi":
                    KKDF = 0;
                    BSMV = 0;
                    break;
                case "Taþýt Kredisi":
                    KKDF = 0.15;
                    BSMV = 0.05;
                    break;
                case "Ticari Kredi":
                    KKDF = 0;
                    BSMV = 0.05;
                    break;
            }

           
            //double brutFaiz = (oran + (oran * BSMV) + (oran * KKDF)) / 100;
            double brutFaiz = (oran + (oran * BSMV) + (oran * KKDF)) / 100;
            double aylikFaiz = brutFaiz / 12;
            double taksit = (Math.Pow(1 + brutFaiz, vade) * brutFaiz) / (Math.Pow(1 + brutFaiz, vade) - 1) * tutar;
            double toplamOdeme = taksit * vade;
            double toplamFaiz = toplamOdeme - tutar;

            lblSonuc.Text = $"Aylýk Taksit: {taksit:F2} TL\nToplam Geri Ödeme: {toplamOdeme:F2} TL\nToplam Faiz: {toplamFaiz:F2} TL";
        }
    }
}