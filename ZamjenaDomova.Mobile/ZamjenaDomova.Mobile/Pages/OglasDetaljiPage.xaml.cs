using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZamjenaDomova.Controls;
using ZamjenaDomova.Model;
using ZamjenaDomova.Model.Requests;

namespace ZamjenaDomova.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OglasDetaljiPage : ContentPage
    {
        public ObservableCollection<Model.ListingImageModel> listingImages;
        public SelectableObservableCollection<SelectableItem<Model.AmenityModel>> AmenitiesItems { get; set; }

        private int _listingId;
        private int _totalImages = 0;
        private string email;
        private string phone;
        private int Height = 0;
        public OglasDetaljiPage(int listingId, bool deletable)
        {
            InitializeComponent();
            listingImages = new ObservableCollection<Model.ListingImageModel>();
            _listingId = listingId;
            GetListingDetails(_listingId);
            if (deletable)
                BtnDelete.IsVisible = true;
        }
        private async void GetListingDetails(int listingId)
        {
            var listing = await APIService.GetListingDetails(listingId);

            lblName.Text = listing.Name;
            lblHomeDesc.Text = listing.ListingDescription;
            lblAreaDesc.Text = listing.AreaDescription;
            lblPersons.Text = listing.Persons.ToString();
            lblBeds.Text = listing.Beds.ToString();
            lblBathrooms.Text = listing.Bathrooms.ToString();
            lblOwner.Text = listing.UserName;
            lblAddress.Text = listing.Address;
            lblCity.Text = listing.City;
            lblTerritory.Text = listing.TerritoryName;
            lblDate.Text = listing.DateApproved.ToString("dd/MM/yyyy");
            email = listing.UserEmail;
            phone = listing.UserPhone;

            Height = 32 * listing.Amenities.Count;
            lvAmenities.ItemsSource = listing.Amenities;
            lvAmenities.HeightRequest = Height;

            var images = await APIService.GetListingImages(listingId);
            if (images != null)
            {
                _totalImages = images.Count;
                foreach (var item in images)
                {
                    listingImages.Add(item);
                }
            }
            crvImages.ItemsSource = listingImages;
        }
        private void crvImages_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            if (e.FirstVisibleItemIndex <= _totalImages)
            {
                var counter = e.FirstVisibleItemIndex + 1;
                lblCounter.Text = counter + " od " + _totalImages;
            }
        }
        private async void BtnContact_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Kontaktiraj", $"Email: {email}\nTelefon: {phone}", "OK");
        }
        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            var answer = await DisplayAlert("Brisanje oglasa", "Jeste li sigurni da želite izbrisati oglas?", "Da", "Ne");
            if (answer)
            {
                var listing = new ListingUpdateRequest
                {
                    Approved = false
                };
                await APIService.UpdateListing(_listingId, listing);
                await Navigation.PopAsync();
            }
        }
    }
}