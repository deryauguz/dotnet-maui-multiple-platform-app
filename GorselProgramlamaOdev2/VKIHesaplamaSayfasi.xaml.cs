using Microsoft.Maui.Controls;
using System;
using System.Globalization;
using System.Linq;

namespace GorselProgramlamaOdev2.Views
{
    public partial class VKIHesaplamaSayfasi : ContentPage
    {
        private bool isUpdating = false;

        public VKIHesaplamaSayfasi()
        {
            InitializeComponent();
            HesaplaVKI();
        }

        private void HesaplaVKI_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (isUpdating) return; 

            isUpdating = true;

            if (sender == SliderKilo)
            {
               
                LabelKilo.Text = $"Kilonuz (KG): {e.NewValue:F1}";
                EntryKilo.Text = $"{e.NewValue:F0}"; 
            }
            else if (sender == SliderBoy)
            {
                LabelBoy.Text = $"Boyunuz (CM): {e.NewValue:F0}";
                EntryBoy.Text = $"{e.NewValue:F0}"; 
            }

            isUpdating = false;
            HesaplaVKI(); 
        }

        private void EntryKilo_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdating) return;

          
            if (double.TryParse(e.NewTextValue.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double yeniKilo))
            {
                if (yeniKilo >= SliderKilo.Minimum && yeniKilo <= SliderKilo.Maximum)
                {
                    isUpdating = true;
                    SliderKilo.Value = yeniKilo;
                    isUpdating = false;
                }
            }
        }

        private void EntryBoy_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isUpdating) return;

            if (double.TryParse(e.NewTextValue.Replace(',', '.'), NumberStyles.Any, CultureInfo.InvariantCulture, out double yeniBoy))
            {
                if (yeniBoy >= SliderBoy.Minimum && yeniBoy <= SliderBoy.Maximum)
                {
                    isUpdating = true;
                    SliderBoy.Value = yeniBoy;
                    isUpdating = false;
                }
            }
        }

        // --- ANA HESAPLAMA METODU ---
        private void HesaplaVKI()
        {
            double kilo = SliderKilo.Value;
            double boyCm = SliderBoy.Value;

            double boyMetre = boyCm / 100.0;

            if (boyMetre <= 0)
            {
                LabelVKIDeger.Text = "VKÝ Deðeri: Hata";
                LabelVKIKategori.Text = "Kategori: Boy 0 olamaz";
                return;
            }

            // VKÝ Hesaplama Formülü: VKÝ = Kilo (kg) / Boy² (m²)
            double vki = kilo / (boyMetre * boyMetre);



            string kategori;

            // VKÝ Sýnýflandýrma
            if (vki < 16)
                kategori = "Ýleri Düzeyde Zayýf";
            else if (vki < 17)
                kategori = "Orta Düzeyde Zayýf";
            else if (vki < 18.5)
                kategori = "Hafif Düzeyde Zayýf";
            else if (vki < 25)
                kategori = "Normal Kilolu";
            else if (vki < 30)
                kategori = "Hafif Þiþman / Fazla Kilolu";
            else if (vki < 35)
                kategori = "1. Derecede Obez";
            else if (vki < 40)
                kategori = "2. Derecede Obez";
            else
                kategori = "3. Derecede Obez / Morbid Obez";


          
            LabelVKIDeger.Text = $"VKÝ Deðeri: {vki:N2}";
            LabelVKIKategori.Text = $"Kategori: {kategori}";
        }
    }
}