using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MojDomPage : ContentPage
    {
        public MojDomPage()
        {
            InitializeComponent();
        }
        private void TapNewHome_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NoviOglasPage());
        }
        private void TapMyHome_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MojiOglasiPage());
        }
    }
}