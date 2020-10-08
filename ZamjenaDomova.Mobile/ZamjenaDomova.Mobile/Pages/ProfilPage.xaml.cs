using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Mobile.Views;

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
        private void TapUnapproved_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MojiOglasiNaCekanjuPage());
        }
        private void TapWishlist_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WishlistPage());
        }
        private void TapLogout_Tapped(object sender, EventArgs e)
        {
            Preferences.Set("access_token", string.Empty);
            Preferences.Set("token_expiration_time", DateTime.Now.AddYears(-1));
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}