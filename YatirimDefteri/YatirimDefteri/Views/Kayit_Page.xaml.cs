using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YatirimDefteri.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kayit_Page : ContentPage
    {
        public Kayit_Page()
        {
            InitializeComponent();
        }

        private void Button_kayit_Clicked(object sender, EventArgs e)
        {
            string kadi = entry_kadi.Text;
            string pass = entry_pass.Text;
            string pass2 = entry_pass2.Text;
            string eposta = entry_eposta.Text;
            if (kadi.Length < 3)
            {
                DisplayAlert("Hata", "Kullanıcı adı en az 3 karakter olmalı", "tamam");
                return;
            }
            if (pass.Length < 6)
            {
                DisplayAlert("Hata", "Şifre en az 6 karakter olmalı", "tamam");
                return;
            }
            if (pass != pass2)
            {
                DisplayAlert("Hata", "Şifreler uyuşmuyor", "tamam");
                return;
            }
            if (eposta.Length < 6)
            {
                DisplayAlert("Hata", "Eposta geçersiz", "tamam");
                return;
            }

            KayitIslemi(kadi, pass, eposta);
        }
        async void KayitIslemi(string kadi, string pass, string eposta)
        {
            Models.Kullanici kll = await App.RestService.Kayit(kadi, pass, eposta);
            if (kll != null)
            {
               
                App.DBService.SaveUser(kll);
                await Navigation.PushModalAsync(new Durumum_Page());
            }
            else
            {
                DisplayAlert("Hata", "Kayıt işlemi sırasında hata oluştu", "tamam");
            }
        }
    }
}