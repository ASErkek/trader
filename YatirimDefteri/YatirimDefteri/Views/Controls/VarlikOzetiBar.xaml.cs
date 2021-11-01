using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YatirimDefteri.Views.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class VarlikOzetiBar : ContentView
    {
        private Models.Durum durum;
        public VarlikOzetiBar()
        {
            InitializeComponent();
            #region test
            /*
            List<Models.Varlik> toplamVarliklar = new List<Models.Varlik>();
            toplamVarliklar.Add(new Models.Varlik(Bankalar.Akbank, VarlikTurleri.TL,200));
            toplamVarliklar.Add(new Models.Varlik(Bankalar.Akbank, VarlikTurleri.USD, 1500));
            listView_Varliklar.ItemsSource = toplamVarliklar;
            label_toplamVarlik.Text = "₺ 231";
            label_toplamKar.Text = "+ 12";
            */
            #endregion

            if (!DesignMode.IsDesignModeEnabled)
            {
                Task.Factory.StartNew(Timer_tick,
                    CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);

            }
        }
        private async void Durum_sorgu()
        {
            durum = App.RestService.DurumSorgula();

            durum.karTL = 0;
        }
        private  void Timer_tick()
        {
            while (true)
            {
                Durum_sorgu();
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (durum != null)
                    {
                        List<Models.Varlik> toplamVarliklar = new List<Models.Varlik>();
                        //varlikMiktari_Altin.IsVisible = false;
                        foreach (Models.Varlik varlik in durum.varliklar)
                        {
                            if ((int)varlik.banka == -1)
                            {
                                toplamVarliklar.Add(varlik);
                            }
                        }

                        label_toplamVarlik.Text = "₺ " + durum.toplamTL.ToString();
                        label_toplamKar.Text = durum.karTL.ToString();
                        if (toplamVarliklar != null)
                        {
                            listView_Varliklar.ItemsSource = toplamVarliklar;
                        }


                    }
                });
                Task.Delay(1000);
            }
            
        }

    }
}