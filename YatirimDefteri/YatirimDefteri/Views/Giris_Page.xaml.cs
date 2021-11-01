using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using YatirimDefteri.Models;

namespace YatirimDefteri.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Giris_Page : ContentPage
    {
        Models.Kullanici kullanici;

        public Giris_Page()
        {
            
            InitializeComponent();
            CheckToken();
        }
        void Init()
        {
            
            ActivitySpinner.IsVisible = false;

            entry_kadi.Completed += (s, e) => entry_pass.Focus();
            //entry_pass.Completed += (s, e) => GirisIslemi();



        }
        private void Button_giris_Clicked(object sender, EventArgs e)
        {
            kullanici = new Models.Kullanici(entry_kadi.Text, entry_pass.Text);
            GirisIslemi();
        }
        async void GirisIslemi()
        {
            ActivitySpinner.IsVisible = true;
            try
            {
                Models.Kullanici kll = await App.RestService.Login(kullanici.kadi,kullanici.pass,kullanici.access_token);
                if(kll != null)
                {
                    kullanici = kll;
                    App.DBService.SaveUser(kullanici);
                    await Navigation.PushModalAsync(new Durumum_Page());
                }
                else
                {
                    DisplayAlert("Hata", "Giriş sırasında hata oluştu", "tamam");
                }
            }
            catch (Exception)
            {

            }

            
            ActivitySpinner.IsVisible = false;
           
        }
        private void CheckToken()
        {
            kullanici = App.DBService.GetUser();
            if (kullanici == null)
            {
                kullanici = new Kullanici();
                return;
            }
            else
            {
                GirisIslemi();
            }
        }

        private void Button_kayit_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Kayit_Page());
        }
    }
}