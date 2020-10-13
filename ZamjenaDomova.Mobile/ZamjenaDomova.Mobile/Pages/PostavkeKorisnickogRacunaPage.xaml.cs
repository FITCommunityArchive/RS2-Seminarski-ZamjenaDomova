using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PostavkeKorisnickogRacunaPage : ContentPage
    {
        private MediaFile file;
        public PostavkeKorisnickogRacunaPage()
        {
            InitializeComponent();
            LoadUser();
        }
        public async void LoadUser()
        {
            var user = await APIService.GetUserDetails();
            EntFirstName.Text = user.FirstName;
            EntLastName.Text = user.LastName;
            EntEmail.Text = user.Email;
            EntPhone.Text = user.PhoneNumber;
            if (user.Image != null && user.Image.Length > 0)
            {
                Stream stream = new MemoryStream(user.Image);
                ImgProfile.Source = ImageSource.FromStream(() => stream);
            }
            else
            {
                ImgProfile.Source = "user.png";
            }
        }

        private async void BtnSave_Clicked(object sender, EventArgs e)
        {
            var request = new AccountSettingsUpdateRequest();
            request.FirstName = EntFirstName.Text;
            request.LastName = EntLastName.Text;
            request.PhoneNumber = EntPhone.Text;
            request.Email = EntEmail.Text;

            await APIService.UpdateAccountSettings(request);
            await Navigation.PopAsync();
        }

        private void TapUploadImage_Tapped(object sender, EventArgs e)
        {
            PickImageFromGallery();
        }

        private async void PickImageFromGallery()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Oops", "Žao nam je, Vaš uređaj ne dozvoljava ovu funkcionalnost.", "OK");
                return;
            }

            PickMediaOptions pick = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
                CompressionQuality = 92
            };
            file = await CrossMedia.Current.PickPhotoAsync(pick);

            if (file == null)
                return;

            ImgProfile.Source = ImageSource.FromStream(() => file.GetStream());
            AddImageToServer();
        }

        private async void AddImageToServer()
        {
            var imageArray = FromFile.ToArray(file.GetStream());

            var response = await APIService.ChangeProfilePicture(imageArray);
            if (response) return;
            await DisplayAlert("Error", "Došlo je do greške. Ponovite upload slike.", "OK");
        }
    }
}