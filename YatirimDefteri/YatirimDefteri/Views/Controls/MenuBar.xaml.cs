using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace YatirimDefteri.Views.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuBar : ContentView
	{
		public MenuBar ()
		{
			InitializeComponent ();
		}

        private void Stacklayout_Header_Summary_Tapped(object sender, EventArgs e)
        {
            
        }
        private void Stacklayout_Header_WatchList_Tapped(object sender, EventArgs e)
        {
        }
        private void Stacklayout_Header_Alarms_Tapped(object sender, EventArgs e)
        {
        }
        private void Stacklayout_Header_Cikis_Tapped(object sender, EventArgs e)
        {
            App.DBService.DeleteUser();
            Navigation.PushModalAsync(new Giris_Page());
        }
        
    }
}