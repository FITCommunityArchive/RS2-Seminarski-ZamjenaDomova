using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Mobile.Views;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
       
        public RegisterPage()
        {
            InitializeComponent();

        }
        private async void BtnRegister_Clicked(object sender, EventArgs e)
        {
            var response = await APIService.RegisterUser(EntFirstName.Text, EntLastName.Text, EntEmail.Text, EntPhone.Text, EntPassword.Text, EntPasswordConfirmation.Text);
            if (response)
            {
                await DisplayAlert("Notifikacija", "Korisnički nalog uspješno kreiran!", "OK");
                await Navigation.PushModalAsync(new LoginPage());
            }
            else
            {
                EntPassword.Text = "";
                EntPasswordConfirmation.Text = "";
                await DisplayAlert("Notifikacija", "Došlo je do greške prilikom kreiranja korisničkog naloga.", "Cancel");
            }
        }
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}