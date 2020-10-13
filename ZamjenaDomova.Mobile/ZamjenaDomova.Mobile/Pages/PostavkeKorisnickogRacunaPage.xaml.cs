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
    public partial class PostavkeKorisnickogRacunaPage : ContentPage
    {
        public PostavkeKorisnickogRacunaPage()
        {
            try
            {
                InitializeComponent();
                LoadUser();
            }
            catch(Exception ex)
            { DisplayAlert("", ex.Message, "OK"); }
        }
        public async void LoadUser()
        {
            var user = await APIService.GetUserDetails();
            EntFirstName.Text = user.FirstName;
            EntLastName.Text = user.LastName;
            EntEmail.Text = user.Email;
            EntPhone.Text = user.PhoneNumber;
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {

        }
    }
}