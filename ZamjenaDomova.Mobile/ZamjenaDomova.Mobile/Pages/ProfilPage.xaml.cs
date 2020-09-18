using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilPage : ContentPage
    {
        public ProfilPage()
        {
            InitializeComponent();

            lblName.Text = Preferences.Get("userName", " ");
        }
        private void TapChangePassword_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PromijeniLozinkuPage());
        }
        private void TapAccSettings_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PostavkeKorisnickogRacunaPage());
        }
    }
}