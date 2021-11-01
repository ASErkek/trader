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
	public partial class Durumum_Page : ContentPage
	{
		public Durumum_Page ()
		{
			InitializeComponent ();
            if (!DesignMode.IsDesignModeEnabled)
            {
                Views.Controls.MenuBar menuBar = new Controls.MenuBar();
                scrollView_header.Content = menuBar;
                Views.Controls.VarlikOzetiBar varlikOzetiBar = new Controls.VarlikOzetiBar();
                stackLayout_varlikOzeti.Children.Add(varlikOzetiBar);

                Views.Controls.KurTakipBar kurTakipBar = new Controls.KurTakipBar();
                stackLayout_kurTakip.Children.Add(kurTakipBar);
            }
        }

	}
}