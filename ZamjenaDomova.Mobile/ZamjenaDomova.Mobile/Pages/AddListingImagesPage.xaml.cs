using ImageToArray;
using Plugin.Media;
using Plugin.Media.Abstractions;
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
    public partial class AddListingImagesPage : ContentPage
    {
            private MediaFile file;
            private int _listingId;
            public AddListingImagesPage(int listingId)
            {
                InitializeComponent();
                _listingId = listingId;
            }

            private async void PickImageFromGallery(Image image)
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("Oops", "Žao nam je, Vaš uređaj ne dozvoljava ovu funkcionalnost.", "OK");
                    return;
                }

                PickMediaOptions pick = new PickMediaOptions()
                {
                    PhotoSize = PhotoSize.Medium,
                    CompressionQuality = 50
                };
                file = await CrossMedia.Current.PickPhotoAsync(pick);

                if (file == null)
                    return;

                image.Source = ImageSource.FromStream(() => file.GetStream());
                AddImageToServer();
            }

            private async void AddImageToServer()
            {
                var imageArray = FromFile.ToArray(file.GetStream());

                var response = await APIService.AddListingImage(_listingId, imageArray);
                if (response) return;
                await DisplayAlert("Error", "Došlo je do greške. Ponovite upload slike.", "OK");
            }

            private void TapImg1_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img1);
            }

            private void TapImg2_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img2);
            }

            private void TapImg3_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img3);
            }

            private void TapImg4_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img4);
            }

            private void TapImg5_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img5);
            }

            private void TapImg6_Tapped(object sender, EventArgs e)
            {
                PickImageFromGallery(Img6);
            }

            private void BtnDone_Clicked(object sender, EventArgs e)
            {
                Navigation.PushModalAsync(new MojDomPage());
                Navigation.RemovePage(this);
            }
        }
    }